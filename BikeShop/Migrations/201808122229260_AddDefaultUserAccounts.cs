namespace BikeShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDefaultUserAccounts : DbMigration
    {
        public override void Up()
        {

            Sql(@"

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'29ebdfab-f7aa-4a91-a853-034d658b37fa', N'admin@bikeshop.com', 0, N'AMnuyxYfOgoS3OzD+gzbW4uK0g0/DT6iILSfEuVaaWhcnNDcQA3cIxkgpYvRQu+PoQ==', N'cf612cd4-a07a-4154-b3b7-2f3c92b75451', NULL, 0, 0, NULL, 1, 0, N'admin@bikeshop.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'625b1016-8306-44a1-8bf1-39af22471d8a', N'guest@bikeshop.com', 0, N'AAA3FQCAJOqjxHY+yBpcw7ifsjI8V0r+WQYNO2/9pyq02srBEKqYZ7l2qUZ8MoWjGQ==', N'd38399a3-eccb-41bf-b41b-e39409e02095', NULL, 0, 0, NULL, 1, 0, N'guest@bikeshop.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd721bf6f-a964-464c-9719-270b367e697d', N'Admin')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'29ebdfab-f7aa-4a91-a853-034d658b37fa', N'd721bf6f-a964-464c-9719-270b367e697d')

");

        }
        
        public override void Down()
        {
        }
    }
}
