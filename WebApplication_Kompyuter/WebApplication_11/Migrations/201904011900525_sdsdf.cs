namespace WebApplication_11.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdsdf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buyurtma",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FoydalanuvchiId = c.Int(),
                        YigishId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Foydalanuvchi", t => t.FoydalanuvchiId)
                .ForeignKey("dbo.Yigish", t => t.YigishId)
                .Index(t => t.FoydalanuvchiId)
                .Index(t => t.YigishId);
            
            CreateTable(
                "dbo.Foydalanuvchi",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Parol = c.String(),
                        RollarId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rollar", t => t.RollarId)
                .Index(t => t.RollarId);
            
            CreateTable(
                "dbo.Rollar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nomi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Buyurtma", "YigishId", "dbo.Yigish");
            DropForeignKey("dbo.Foydalanuvchi", "RollarId", "dbo.Rollar");
            DropForeignKey("dbo.Buyurtma", "FoydalanuvchiId", "dbo.Foydalanuvchi");
            DropIndex("dbo.Foydalanuvchi", new[] { "RollarId" });
            DropIndex("dbo.Buyurtma", new[] { "YigishId" });
            DropIndex("dbo.Buyurtma", new[] { "FoydalanuvchiId" });
            DropTable("dbo.Rollar");
            DropTable("dbo.Foydalanuvchi");
            DropTable("dbo.Buyurtma");
        }
    }
}
