namespace ASPMVC_EF_Music.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tracks", "Extention", c => c.String());
            AlterColumn("dbo.Tracks", "name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tracks", "name", c => c.String());
            AlterColumn("dbo.Tracks", "Extention", c => c.String(nullable: false));
        }
    }
}
