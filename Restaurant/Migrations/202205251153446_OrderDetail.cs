namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        OrderDetailID = c.Int(nullable: false, identity: true),
                        FoodID = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                        Quantity = c.Int(),
                        Price = c.Double(),
                    })
                .PrimaryKey(t => t.OrderDetailID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OrderDetail");
        }
    }
}
