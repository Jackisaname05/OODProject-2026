    namespace OODProject_2026.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CharacterEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        DebutYear = c.Int(nullable: false),
                        Publisher = c.String(nullable: false, maxLength: 80),
                        Description = c.String(nullable: false, maxLength: 800),
                        ComicVineCharacterId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CharacterEntities");
        }
    }
}
