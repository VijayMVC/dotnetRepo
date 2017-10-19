namespace Movie_Catalog_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDirectorandYear : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        DirectorId = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.DirectorId);
            
            CreateIndex("dbo.Movies", "DirectorId");
            AddForeignKey("dbo.Movies", "DirectorId", "dbo.Directors", "DirectorId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "DirectorId", "dbo.Directors");
            DropIndex("dbo.Movies", new[] { "DirectorId" });
            DropTable("dbo.Directors");
        }
    }
}
