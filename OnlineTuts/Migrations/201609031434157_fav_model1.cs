namespace OnlineTuts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fav_model1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        FavID = c.Int(nullable: false, identity: true),
                        ApplicationUserID = c.String(maxLength: 128),
                        TutorialID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FavID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .ForeignKey("dbo.Tutorials", t => t.TutorialID, cascadeDelete: true)
                .Index(t => t.ApplicationUserID)
                .Index(t => t.TutorialID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favorites", "TutorialID", "dbo.Tutorials");
            DropForeignKey("dbo.Favorites", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Favorites", new[] { "TutorialID" });
            DropIndex("dbo.Favorites", new[] { "ApplicationUserID" });
            DropTable("dbo.Favorites");
        }
    }
}
