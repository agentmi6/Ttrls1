namespace OnlineTuts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init98 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "CommentDateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "CommentDateCreated");
        }
    }
}
