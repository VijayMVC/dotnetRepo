namespace CarDealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ident : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "UserName", c => c.String());
            AddColumn("dbo.Employees", "OldUserName", c => c.String());
            DropColumn("dbo.Employees", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Name", c => c.String());
            DropColumn("dbo.Employees", "OldUserName");
            DropColumn("dbo.Employees", "UserName");
        }
    }
}
