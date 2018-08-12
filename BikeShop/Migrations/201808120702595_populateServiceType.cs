namespace BikeShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateServiceType : DbMigration
    {
        public override void Up()
        {
            //Add logic to populate MembershipType table with my business logic
            Sql("INSERT INTO ServiceTypes " +
                "(ServiceTypeName)" +
                " Values('Reparation')");

            Sql("INSERT INTO ServiceTypes " +
                "(ServiceTypeName)" +
                " Values('Maintenance')");


        }

        public override void Down()
        {
        }
    }
}
