namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeGenreTableKeyType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gigs", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Gigs", new[] { "Genre_Id" });
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Genres", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Gigs", "Genre_Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Genres", "Id");
            CreateIndex("dbo.Gigs", "Genre_Id");
            AddForeignKey("dbo.Gigs", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Gigs", new[] { "Genre_Id" });
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Gigs", "Genre_Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Genres", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Genres", "Id");
            CreateIndex("dbo.Gigs", "Genre_Id");
            AddForeignKey("dbo.Gigs", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
    }
}
