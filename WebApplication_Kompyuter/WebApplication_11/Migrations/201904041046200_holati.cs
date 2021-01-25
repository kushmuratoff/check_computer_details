namespace WebApplication_11.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class holati : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buyurtma", "Holati", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buyurtma", "Holati");
        }
    }
}
