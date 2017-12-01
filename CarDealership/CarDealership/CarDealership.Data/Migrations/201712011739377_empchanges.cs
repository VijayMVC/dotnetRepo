namespace CarDealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class empchanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "OldPassword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "OldPassword");
        }
    }
}
