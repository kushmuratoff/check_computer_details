namespace WebApplication_11.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kalonka", "Kalon_rasm", c => c.String());
            AddColumn("dbo.Kompaniya", "Komp_rasm", c => c.String());
            AddColumn("dbo.Klaviatura", "Klav_rasm", c => c.String());
            AddColumn("dbo.Manitor", "Mon_rasm", c => c.String());
            AddColumn("dbo.OpSistema", "OS_rasm", c => c.String());
            AddColumn("dbo.Protsessor", "Prots_rasm", c => c.String());
            AddColumn("dbo.OZU", "OZU_rasm", c => c.String());
            AddColumn("dbo.VideoKarta", "Video_rasm", c => c.String());
            AddColumn("dbo.Xotira", "Xotira_rasm", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Xotira", "Xotira_rasm");
            DropColumn("dbo.VideoKarta", "Video_rasm");
            DropColumn("dbo.OZU", "OZU_rasm");
            DropColumn("dbo.Protsessor", "Prots_rasm");
            DropColumn("dbo.OpSistema", "OS_rasm");
            DropColumn("dbo.Manitor", "Mon_rasm");
            DropColumn("dbo.Klaviatura", "Klav_rasm");
            DropColumn("dbo.Kompaniya", "Komp_rasm");
            DropColumn("dbo.Kalonka", "Kalon_rasm");
        }
    }
}
