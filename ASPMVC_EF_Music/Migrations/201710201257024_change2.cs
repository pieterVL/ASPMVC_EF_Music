namespace ASPMVC_EF_Music.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Albums", "name", c => c.String(nullable: false));
            AlterColumn("dbo.Genres", "genreName", c => c.String(nullable: false));
            AlterColumn("dbo.People", "name", c => c.String(nullable: false));
            AlterColumn("dbo.Roles", "role", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Roles", "role", c => c.String());
            AlterColumn("dbo.People", "name", c => c.String());
            AlterColumn("dbo.Genres", "genreName", c => c.String());
            AlterColumn("dbo.Albums", "name", c => c.String());
        }
    }
}
