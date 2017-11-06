namespace CarDealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CarModels", "MakeID", "dbo.Makes");
            DropIndex("dbo.CarModels", new[] { "MakeID" });
            RenameColumn(table: "dbo.CarModels", name: "MakeID", newName: "Make_MakeID");
            AddColumn("dbo.Makes", "ModelID", c => c.Int(nullable: false));
            AlterColumn("dbo.CarModels", "Make_MakeID", c => c.Int());
            CreateIndex("dbo.CarModels", "Make_MakeID");
            AddForeignKey("dbo.CarModels", "Make_MakeID", "dbo.Makes", "MakeID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarModels", "Make_MakeID", "dbo.Makes");
            DropIndex("dbo.CarModels", new[] { "Make_MakeID" });
            AlterColumn("dbo.CarModels", "Make_MakeID", c => c.Int(nullable: false));
            DropColumn("dbo.Makes", "ModelID");
            RenameColumn(table: "dbo.CarModels", name: "Make_MakeID", newName: "MakeID");
            CreateIndex("dbo.CarModels", "MakeID");
            AddForeignKey("dbo.CarModels", "MakeID", "dbo.Makes", "MakeID", cascadeDelete: true);
        }
    }
}
