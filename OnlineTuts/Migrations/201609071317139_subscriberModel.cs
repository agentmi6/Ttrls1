namespace OnlineTuts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subscriberModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SubName = c.String(),
                        ApplicationUserID = c.String(maxLength: 128),
                        SubUserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .ForeignKey("dbo.AspNetUsers", t => t.SubUserID)
                .Index(t => t.ApplicationUserID)
                .Index(t => t.SubUserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subs", "SubUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Subs", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Subs", new[] { "SubUserID" });
            DropIndex("dbo.Subs", new[] { "ApplicationUserID" });
            DropTable("dbo.Subs");
        }
    }
}
