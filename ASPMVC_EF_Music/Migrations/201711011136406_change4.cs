namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change4 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.GenreModels", newName: "Genres");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Genres", newName: "GenreModels");
        }
    }
}
