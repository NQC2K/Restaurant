namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        FoodID = c.Int(nullable: false, identity: true),
                        FoodName = c.String(nullable: false, maxLength: 255, unicode: false),
                        CateId = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        PriceDiscount = c.Double(nullable: false),
                        Image = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FoodID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Foods");
        }
    }
}
