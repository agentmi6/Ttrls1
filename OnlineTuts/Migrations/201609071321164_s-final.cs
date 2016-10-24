namespace OnlineTuts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sfinal : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subscriptions", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Subscriptions", new[] { "ApplicationUserID" });
            AddColumn("dbo.Subs", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Subs", "ApplicationUser_Id");
            AddForeignKey("dbo.Subs", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropTable("dbo.Subscriptions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SubUserID = c.String(),
                        SubName = c.String(),
                        ApplicationUserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.Subs", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Subs", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Subs", "ApplicationUser_Id");
            CreateIndex("dbo.Subscriptions", "ApplicationUserID");
            AddForeignKey("dbo.Subscriptions", "ApplicationUserID", "dbo.AspNetUsers", "Id");
        }
    }
}
