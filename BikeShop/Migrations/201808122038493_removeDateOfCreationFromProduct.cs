namespace BikeShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeDateOfCreationFromProduct : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "DateCreation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "DateCreation", c => c.DateTime());
        }
    }
}
