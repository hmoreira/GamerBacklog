namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GamePlatforms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        PlatformId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId)
                .ForeignKey("dbo.Platforms", t => t.PlatformId, cascadeDelete: true)
                .Index(t => t.GameId)
                .Index(t => t.PlatformId);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Platform = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Platforms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GamePlatforms", "PlatformId", "dbo.Platforms");
            DropForeignKey("dbo.GamePlatforms", "GameId", "dbo.Games");
            DropIndex("dbo.GamePlatforms", new[] { "PlatformId" });
            DropIndex("dbo.GamePlatforms", new[] { "GameId" });
            DropTable("dbo.Platforms");
            DropTable("dbo.Games");
            DropTable("dbo.GamePlatforms");
        }
    }
}
