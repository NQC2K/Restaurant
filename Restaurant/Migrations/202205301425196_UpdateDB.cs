namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Foods", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Foods", "Image", c => c.String(nullable: false));
        }
    }
}
