namespace Movie_Catalog_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DirectorAndYear : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime());
            AddColumn("dbo.Movies", "DirectorId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "DirectorId");
            DropColumn("dbo.Movies", "ReleaseDate");
        }
    }
}
