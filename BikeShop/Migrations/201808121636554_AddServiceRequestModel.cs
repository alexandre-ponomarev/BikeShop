namespace BikeShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddServiceRequestModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        AppointmentDate = c.DateTime(nullable: false),
                        ServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ServiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceRequests", "ServiceId", "dbo.Services");
            DropIndex("dbo.ServiceRequests", new[] { "ServiceId" });
            DropTable("dbo.ServiceRequests");
        }
    }
}
