namespace CarDealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Makes", "AnEmployee_EmployeeID", "dbo.Employees");
            DropIndex("dbo.Makes", new[] { "AnEmployee_EmployeeID" });
            AddColumn("dbo.Makes", "AddedBy", c => c.String());
            DropColumn("dbo.Makes", "AnEmployee_EmployeeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Makes", "AnEmployee_EmployeeID", c => c.Int());
            DropColumn("dbo.Makes", "AddedBy");
            CreateIndex("dbo.Makes", "AnEmployee_EmployeeID");
            AddForeignKey("dbo.Makes", "AnEmployee_EmployeeID", "dbo.Employees", "EmployeeID");
        }
    }
}
