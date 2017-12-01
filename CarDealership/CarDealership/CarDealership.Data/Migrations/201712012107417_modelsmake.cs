namespace CarDealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelsmake : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CarModels", "AMake_MakeID", "dbo.Makes");
            DropIndex("dbo.CarModels", new[] { "AMake_MakeID" });
            AddColumn("dbo.CarModels", "Make", c => c.String());
            DropColumn("dbo.CarModels", "AMake_MakeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CarModels", "AMake_MakeID", c => c.Int());
            DropColumn("dbo.CarModels", "Make");
            CreateIndex("dbo.CarModels", "AMake_MakeID");
            AddForeignKey("dbo.CarModels", "AMake_MakeID", "dbo.Makes", "MakeID");
        }
    }
}
