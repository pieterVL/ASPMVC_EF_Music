namespace ASPMVC_EF_Music.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        releasedate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        genreName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        dayOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Track_Album",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrackSequence = c.Int(nullable: false),
                        TrackId = c.Int(nullable: false),
                        AlbumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Tracks", t => t.TrackId, cascadeDelete: true)
                .Index(t => t.TrackId)
                .Index(t => t.AlbumId);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Extention = c.String(),
                        name = c.String(),
                        length = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Track_Genre",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrackId = c.Int(nullable: false),
                        GenreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreID, cascadeDelete: true)
                .ForeignKey("dbo.Tracks", t => t.TrackId, cascadeDelete: true)
                .Index(t => t.TrackId)
                .Index(t => t.GenreID);
            
            CreateTable(
                "dbo.Track_Person_Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        TrackId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Tracks", t => t.TrackId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.TrackId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Track_Person_Role", "TrackId", "dbo.Tracks");
            DropForeignKey("dbo.Track_Person_Role", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Track_Person_Role", "PersonId", "dbo.People");
            DropForeignKey("dbo.Track_Genre", "TrackId", "dbo.Tracks");
            DropForeignKey("dbo.Track_Genre", "GenreID", "dbo.Genres");
            DropForeignKey("dbo.Track_Album", "TrackId", "dbo.Tracks");
            DropForeignKey("dbo.Track_Album", "AlbumId", "dbo.Albums");
            DropIndex("dbo.Track_Person_Role", new[] { "RoleId" });
            DropIndex("dbo.Track_Person_Role", new[] { "TrackId" });
            DropIndex("dbo.Track_Person_Role", new[] { "PersonId" });
            DropIndex("dbo.Track_Genre", new[] { "GenreID" });
            DropIndex("dbo.Track_Genre", new[] { "TrackId" });
            DropIndex("dbo.Track_Album", new[] { "AlbumId" });
            DropIndex("dbo.Track_Album", new[] { "TrackId" });
            DropTable("dbo.Track_Person_Role");
            DropTable("dbo.Track_Genre");
            DropTable("dbo.Tracks");
            DropTable("dbo.Track_Album");
            DropTable("dbo.Roles");
            DropTable("dbo.People");
            DropTable("dbo.Genres");
            DropTable("dbo.Albums");
        }
    }
}
