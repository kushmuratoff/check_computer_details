namespace WebApplication_11.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yangi2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OpSistema", "Narxi", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OpSistema", "Narxi");
        }
    }
}
