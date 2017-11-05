namespace CarDealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class custPurchID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "PurchaseID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "PurchaseID");
        }
    }
}
