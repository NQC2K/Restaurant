namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _null : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Foods", "Price", c => c.Double());
            AlterColumn("dbo.Foods", "PriceDiscount", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Foods", "PriceDiscount", c => c.Double(nullable: false));
            AlterColumn("dbo.Foods", "Price", c => c.Double(nullable: false));
        }
    }
}
