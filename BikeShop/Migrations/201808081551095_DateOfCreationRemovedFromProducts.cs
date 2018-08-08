namespace BikeShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateOfCreationRemovedFromProducts : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "DateCreation", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "DateCreation", c => c.DateTime(nullable: false));
        }
    }
}
