namespace DvdLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dvds",
                c => new
                    {
                        DvdId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 220),
                        Director = c.String(maxLength: 75),
                        ReleaseYear = c.Int(),
                        Rating = c.String(maxLength: 5),
                        Notes = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.DvdId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Dvds");
        }
    }
}
