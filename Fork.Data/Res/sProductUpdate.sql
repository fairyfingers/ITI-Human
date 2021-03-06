﻿--SetupConfig: {}
create proc FRK.sProductUpdate (
	@ActorId int,
	@ProductId int,
	@Name nvarchar(256),
	@Desc nvarchar(512),
	@Url nvarchar(max),
	@Success bit = 0 output
)
as
begin
	--[beginsp]
	
	--<PreCreate revert />

	declare @previousName nvarchar(256);
	declare @previousDesc nvarchar(512);
	declare @previousUrl nvarchar(max);
	declare @newName nvarchar(256);
	declare @newDesc nvarchar(512);
	declare @newUrl nvarchar(max);

	set @previousName = (select [Name] from FRK.tProduct where ProductId = @ProductId);
	set @previousDesc = (select [Desc] from FRK.tProduct where ProductId = @ProductId);
	set @previousUrl = (select [Url] from FRK.tProduct where ProductId = @ProductId);

	if (@Name = null)
		set @Name = @previousName;
		
	if (@Desc = null)
		set @Desc = @previousDesc;

	if (@Url = null)
		set @Url = @previousUrl;

	update FRK.tProduct set [Name] = @Name where ProductId = @ProductId;
	update FRK.tProduct set [Desc] = @Desc where ProductId = @ProductId;
	update FRK.tProduct set [Url] = @Url where ProductId = @ProductId;

	set @newName = (select [Name] from FRK.tProduct where ProductId = @ProductId);
	set @newDesc = (select [Desc] from FRK.tProduct where ProductId = @ProductId);
	set @newUrl = (select [Url] from FRK.tProduct where ProductId = @ProductId);

	if (@newName != @previousName or @newDesc != @previousDesc or @newUrl != @previousUrl)
		set @Success = 1;

	--<PostCreate />
	
	--[endsp]
end;