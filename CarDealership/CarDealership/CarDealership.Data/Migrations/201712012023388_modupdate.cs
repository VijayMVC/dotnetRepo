namespace CarDealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CarModels", "AnEmployee_EmployeeID", "dbo.Employees");
            DropIndex("dbo.CarModels", new[] { "AnEmployee_EmployeeID" });
            AddColumn("dbo.CarModels", "AddedBy", c => c.String());
            DropColumn("dbo.CarModels", "AnEmployee_EmployeeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CarModels", "AnEmployee_EmployeeID", c => c.Int());
            DropColumn("dbo.CarModels", "AddedBy");
            CreateIndex("dbo.CarModels", "AnEmployee_EmployeeID");
            AddForeignKey("dbo.CarModels", "AnEmployee_EmployeeID", "dbo.Employees", "EmployeeID");
        }
    }
}
