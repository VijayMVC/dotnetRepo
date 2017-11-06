namespace CarDealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carmodelmakefix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CarModels", "Make_MakeID", "dbo.Makes");
            DropIndex("dbo.CarModels", new[] { "Make_MakeID" });
            RenameColumn(table: "dbo.CarModels", name: "Make_MakeID", newName: "MakeID");
            AlterColumn("dbo.CarModels", "MakeID", c => c.Int(nullable: false));
            CreateIndex("dbo.CarModels", "MakeID");
            AddForeignKey("dbo.CarModels", "MakeID", "dbo.Makes", "MakeID", cascadeDelete: true);
            DropColumn("dbo.Makes", "ModelID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Makes", "ModelID", c => c.Int(nullable: false));
            DropForeignKey("dbo.CarModels", "MakeID", "dbo.Makes");
            DropIndex("dbo.CarModels", new[] { "MakeID" });
            AlterColumn("dbo.CarModels", "MakeID", c => c.Int());
            RenameColumn(table: "dbo.CarModels", name: "MakeID", newName: "Make_MakeID");
            CreateIndex("dbo.CarModels", "Make_MakeID");
            AddForeignKey("dbo.CarModels", "Make_MakeID", "dbo.Makes", "MakeID");
        }
    }
}
