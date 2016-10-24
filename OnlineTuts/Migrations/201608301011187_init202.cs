namespace OnlineTuts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init202 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Comments", "CommentDateCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "CommentDateCreated", c => c.DateTime(nullable: false));
        }
    }
}
