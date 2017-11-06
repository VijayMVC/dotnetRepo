namespace CarDealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarModels", "Make_MakeID", c => c.Int());
            AddColumn("dbo.Vehicles", "CarModel_CarModelID", c => c.Int());
            CreateIndex("dbo.CarModels", "Make_MakeID");
            CreateIndex("dbo.Vehicles", "CarModel_CarModelID");
            AddForeignKey("dbo.CarModels", "Make_MakeID", "dbo.Makes", "MakeID");
            AddForeignKey("dbo.Vehicles", "CarModel_CarModelID", "dbo.CarModels", "CarModelID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "CarModel_CarModelID", "dbo.CarModels");
            DropForeignKey("dbo.CarModels", "Make_MakeID", "dbo.Makes");
            DropIndex("dbo.Vehicles", new[] { "CarModel_CarModelID" });
            DropIndex("dbo.CarModels", new[] { "Make_MakeID" });
            DropColumn("dbo.Vehicles", "CarModel_CarModelID");
            DropColumn("dbo.CarModels", "Make_MakeID");
        }
    }
}
