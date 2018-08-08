namespace BikeShop.Migrations
{
    using System;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Migrations;
    
    public partial class DropCustomersTable : DbMigration
    {
        public override void Up()
        {

            //drop table Customers
            DropTable("Customers");

           // Sql("DROP Table Customers");


        }

        public override void Down()
        {
        }


    }
}
