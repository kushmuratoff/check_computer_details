namespace WebApplication_11.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YANGI1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Foydalanuvchi", "RollarId", "dbo.Rollar");
            DropIndex("dbo.Foydalanuvchi", new[] { "RollarId" });
            CreateTable(
                "dbo.Userlar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        RolesId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RolesId)
                .Index(t => t.RolesId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nomi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Foydalanuvchi", "UserlarId", c => c.Int());
            CreateIndex("dbo.Foydalanuvchi", "UserlarId");
            AddForeignKey("dbo.Foydalanuvchi", "UserlarId", "dbo.Userlar", "Id");
            DropColumn("dbo.Foydalanuvchi", "Login");
            DropColumn("dbo.Foydalanuvchi", "Parol");
            DropColumn("dbo.Foydalanuvchi", "RollarId");
            DropTable("dbo.Rollar");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Rollar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nomi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Foydalanuvchi", "RollarId", c => c.Int());
            AddColumn("dbo.Foydalanuvchi", "Parol", c => c.String());
            AddColumn("dbo.Foydalanuvchi", "Login", c => c.String());
            DropForeignKey("dbo.Foydalanuvchi", "UserlarId", "dbo.Userlar");
            DropForeignKey("dbo.Userlar", "RolesId", "dbo.Roles");
            DropIndex("dbo.Userlar", new[] { "RolesId" });
            DropIndex("dbo.Foydalanuvchi", new[] { "UserlarId" });
            DropColumn("dbo.Foydalanuvchi", "UserlarId");
            DropTable("dbo.Roles");
            DropTable("dbo.Userlar");
            CreateIndex("dbo.Foydalanuvchi", "RollarId");
            AddForeignKey("dbo.Foydalanuvchi", "RollarId", "dbo.Rollar", "Id");
        }
    }
}
