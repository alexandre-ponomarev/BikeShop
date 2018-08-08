namespace BikeShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateCategories_Version_02 : DbMigration
    {
        public override void Up()
        {
            //this is for update all products with category 1
            Sql("UPDATE Products Set CategoryID = 1");

            //this is for update category 1 and 2
            Sql("UPDATE Categories Set CategoryName = 'Bikes' Where CategoryID = 1");
            Sql("UPDATE Categories Set CategoryName = 'Accesories' Where CategoryID = 2");

            //this is for delete  category != (1 and 2)
            Sql("DELETE Categories Where CategoryID not in (1, 2)");

        }

        public override void Down()
        {
        }
    }
}
