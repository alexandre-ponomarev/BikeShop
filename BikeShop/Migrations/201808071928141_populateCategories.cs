namespace BikeShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateCategories : DbMigration
    {
        public override void Up()
        {
            //Add logic to populate MembershipType table with my business logic
            Sql("INSERT INTO Categories " +
                "(CategoryName)" +
                " Values('Road Bikes')");

            Sql("INSERT INTO Categories " +
                "(CategoryName)" +
                " Values('Cyclocross Bikes')");

            Sql("INSERT INTO Categories " +
                "(CategoryName)" +
                " Values('Touring Bikes')");

            Sql("INSERT INTO Categories " +
                "(CategoryName)" +
                " Values('Adventure Road Bikes')");

        }

        public override void Down()
        {
        }
    }
}
