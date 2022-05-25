namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Orders", newName: "Order");
            DropTable("dbo.OrderDetails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailsID = c.Int(nullable: false),
                        FoodID = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                        Quantity = c.Int(),
                        Price = c.Double(),
                    })
                .PrimaryKey(t => t.OrderDetailsID);
            
            RenameTable(name: "dbo.Order", newName: "Orders");
        }
    }
}
