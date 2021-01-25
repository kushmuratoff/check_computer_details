namespace WebApplication_11.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ryhwgw : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Foydalanuvchi", "FISH", c => c.String());
            AddColumn("dbo.Foydalanuvchi", "Uy_manzili", c => c.String());
            AddColumn("dbo.Foydalanuvchi", "Tel_nomeri", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Foydalanuvchi", "Tel_nomeri");
            DropColumn("dbo.Foydalanuvchi", "Uy_manzili");
            DropColumn("dbo.Foydalanuvchi", "FISH");
        }
    }
}
