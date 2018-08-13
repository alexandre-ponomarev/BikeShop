namespace BikeShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropPriceFromService : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Services", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "Price", c => c.Single(nullable: false));
        }
    }
}
