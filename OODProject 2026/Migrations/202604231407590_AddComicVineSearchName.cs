namespace OODProject_2026.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddComicVineSearchName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CharacterEntities", "ComicVineSearchName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CharacterEntities", "ComicVineSearchName");
        }
    }
}
