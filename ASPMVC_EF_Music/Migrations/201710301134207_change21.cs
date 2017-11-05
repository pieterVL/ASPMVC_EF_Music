namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change21 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AlbumModels", newName: "Albums");
            RenameTable(name: "dbo.PersonModels", newName: "People");
            RenameTable(name: "dbo.RoleModels", newName: "Roles");
            RenameTable(name: "dbo.Track_AlbumModel", newName: "Track_Album");
            RenameTable(name: "dbo.TrackModels", newName: "Tracks");
            RenameTable(name: "dbo.Track_GenreModel", newName: "Track_Genre");
            RenameTable(name: "dbo.Track_Person_RoleModel", newName: "Track_Person_Role");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Track_Person_Role", newName: "Track_Person_RoleModel");
            RenameTable(name: "dbo.Track_Genre", newName: "Track_GenreModel");
            RenameTable(name: "dbo.Tracks", newName: "TrackModels");
            RenameTable(name: "dbo.Track_Album", newName: "Track_AlbumModel");
            RenameTable(name: "dbo.Roles", newName: "RoleModels");
            RenameTable(name: "dbo.People", newName: "PersonModels");
            RenameTable(name: "dbo.Albums", newName: "AlbumModels");
        }
    }
}
