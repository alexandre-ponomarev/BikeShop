namespace BikeShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropCustomerTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Customers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Firstname = c.String(nullable: false, maxLength: 80),
                        Lasttname = c.String(nullable: false, maxLength: 80),
                        Address = c.String(nullable: false, maxLength: 100),
                        PhoneNumber = c.String(nullable: false, maxLength: 30),
                        PostalCode = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.CustomerID);
            
        }
    }
}
