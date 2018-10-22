﻿using API.Models.Product;
using CK.SqlServer;
using Dapper;
using ITI.Human.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Product
{
    /// <summary>
    /// Handles any database interaction concerning Products.
    /// </summary>
    public class ProductService
    {
        public ProductTable ProductTable { get; }

        public ProductService(ProductTable table)
        {
            ProductTable = table;
        }

        /// <summary>
        /// Gets all Products from database.
        /// </summary>
        /// <returns>The PublicDataProduct IReadOnlyCollection.</returns>
        public async Task<IReadOnlyCollection<PublicDataProduct>> GetAll()
        {
            using (var ctx = new SqlStandardCallContext())
            {
                var result = await ctx[ProductTable].Connection
                    .QueryAsync<PublicDataProduct>(
                        @"SELECT
                            *
                        FROM ITIH.tProduct;"
                    );
                return result.ToArray();
            }
        }

        /// <summary>
        /// Gets a particular Product.
        /// </summary>
        /// <param name="productId">Product id.</param>
        /// <returns></returns>
        public async Task<PublicDataProduct> Get(int productId)
        {
            using (var ctx = new SqlStandardCallContext())
            {
                return await ctx[ProductTable].Connection
                    .QueryFirstOrDefaultAsync<PublicDataProduct>(
                        @"SELECT
                            *
                        FROM ITIH.tProduct
                        WHERE ProductId = @id;",
                        new { id = productId }
                    );
            }
        }

        public async Task Create(string name, string desc, DateTime creationDate)
        {
            using (var ctx = new SqlStandardCallContext())
            {
                // ...
            }
        }
    }
}