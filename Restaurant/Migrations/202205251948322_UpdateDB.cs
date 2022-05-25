namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.OrderDetail");
            AddPrimaryKey("dbo.OrderDetail", new[] { "OrderID", "FoodID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.OrderDetail");
            AddPrimaryKey("dbo.OrderDetail", new[] { "FoodID", "OrderID" });
        }
    }
}
