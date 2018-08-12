namespace BikeShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addServiceAndServiceTypeTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceID = c.Int(nullable: false, identity: true),
                        ServiceName = c.String(nullable: false, maxLength: 100),
                        ServiceDetail = c.String(nullable: false, maxLength: 500),
                        Price = c.Single(nullable: false),
                        Image = c.Binary(storeType: "image"),
                        ServiceTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceID)
                .ForeignKey("dbo.ServiceTypes", t => t.ServiceTypeID, cascadeDelete: true)
                .Index(t => t.ServiceTypeID);
            
            CreateTable(
                "dbo.ServiceTypes",
                c => new
                    {
                        ServiceTypeID = c.Int(nullable: false, identity: true),
                        ServiceTypeName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ServiceTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "ServiceTypeID", "dbo.ServiceTypes");
            DropIndex("dbo.Services", new[] { "ServiceTypeID" });
            DropTable("dbo.ServiceTypes");
            DropTable("dbo.Services");
        }
    }
}
