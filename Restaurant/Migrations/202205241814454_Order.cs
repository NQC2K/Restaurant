namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Order : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailsID = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                        Quantity = c.Int(),
                        Price = c.Double(),
                    })
                .PrimaryKey(t => new { t.OrderDetailsID, t.OrderID });
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        ShipName = c.String(nullable: false, maxLength: 255, unicode: false),
                        ShipAddress = c.String(nullable: false, maxLength: 50, unicode: false),
                        ShipEmail = c.String(nullable: false, maxLength: 50, unicode: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
        }
    }
}
