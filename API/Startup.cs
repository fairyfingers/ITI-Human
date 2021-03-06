﻿using API.Services.Auth;
using API.Services.Classroom;
using API.Services.Github;
using API.Services.Order;
using API.Services.Product;
using API.Services.Project;
using API.Services.Storage;
using API.Services.User;
using CK.AspNet.Auth;
using CK.Auth;
using CK.Core;
using CK.DB.AspNet.Auth;
using Fork.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _environment;


        public Startup(IConfiguration conf, IHostingEnvironment env)
        {
            _configuration = conf;
            _environment = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // This authentication system will be used by mobile app ONLY.
            services.AddAuthentication(WebFrontAuthOptions.OnlyAuthenticationScheme)
            .AddWebFrontAuth(options =>
             {
                 options.ExpireTimeSpan = TimeSpan.FromHours(1);
                 options.SlidingExpirationTime = TimeSpan.FromHours(1);
             }).AddOAuth("GitHub", options =>
             {
                 options.ClientId = _configuration["GitHubApp:ClientId"];
                 options.ClientSecret = _configuration["GitHubApp:ClientSecret"];
                 options.CallbackPath = new PathString("/signin-github");

                 options.Scope.Add("user:email");
                 options.Scope.Add("user:profile");
                 options.AuthorizationEndpoint = "https://github.com/login/oauth/authorize";
                 options.TokenEndpoint = "https://github.com/login/oauth/access_token";
                 options.UserInformationEndpoint = "https://api.github.com/user";

                 options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
                 options.ClaimActions.MapJsonKey(ClaimTypes.Name, "name");
                 options.ClaimActions.MapJsonKey("urn:github:login", "login");
                 options.ClaimActions.MapJsonKey("urn:github:url", "html_url");
                 options.ClaimActions.MapJsonKey("urn:github:avatar", "avatar_url");

                 options.Events = new OAuthEventHandler()
                 {
                     OnCreatingTicket = async context =>
                     {
                         var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
                         request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                         request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);

                         var response = await context.Backchannel.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, context.HttpContext.RequestAborted);
                         response.EnsureSuccessStatusCode();

                         var user = JObject.Parse(await response.Content.ReadAsStringAsync());

                         context.RunClaimActions(user);
                     }
                 };
             });

            // -------------------------------------------------

            if (_environment.IsDevelopment())
            {
                var dllPath = _configuration["StObjMap:Path"];
                if (dllPath != null)
                {
                    var parentPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppContext.BaseDirectory)))));
                    dllPath = Path.Combine(parentPath, dllPath);
                    File.Copy(dllPath, Path.Combine(AppContext.BaseDirectory, "CK.StObj.AutoAssembly.dll"), true);
                }
            }
            services.AddStObjMap("CK.StObj.AutoAssembly");

            services.AddSingleton<IAuthenticationTypeSystem, StdAuthenticationTypeSystem>();
            services.AddSingleton<IWebFrontAuthLoginService, SqlWebFrontAuthLoginService>();
            services.AddSingleton<IWebFrontAuthAutoCreateAccountService, AutoCreateAccountService>();
            services.AddSingleton<AuthCheckService>();
            services.AddSingleton<ClassroomService>();
            services.AddSingleton<GithubClient>();
            services.AddSingleton<GithubService>();
            services.AddSingleton<OrderDueServices>();
            services.AddSingleton<OrderService>();
            services.AddSingleton<OrderedProductService>();
            services.AddSingleton<ProductService>();
            services.AddSingleton<ProjectService>();
            services.AddSingleton<SLPService>();
            services.AddSingleton<StorageService>();
            services.AddSingleton<UserBalanceService>();
            services.AddSingleton<UserService>();
            services.AddSingleton<UserReferenceTooltipService>();

            services.AddCors();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseRequestMonitor();
            app.UseCors(builder =>
                builder.AllowAnyHeader().AllowCredentials().AllowAnyMethod().AllowAnyOrigin());
            app.UseAuthentication();
            app.UseMvc();
        }
    }

    internal class OAuthEventHandler : OAuthEvents
    {
        public override Task TicketReceived(TicketReceivedContext c)
        {
            var authService = c.HttpContext.RequestServices.GetRequiredService<WebFrontAuthService>();
            return authService.HandleRemoteAuthentication<IExtendedUserGitHubInfo>(c, payload =>
            {
                payload.GitHubAccountId = c.Principal.FindFirst(ClaimTypes.NameIdentifier).Value;
                payload.Name = c.Principal.FindFirst(ClaimTypes.Name).Value;
                payload.AvatarUrl = c.Principal.FindFirst("urn:github:avatar").Value;
            });
        }
    }
}
