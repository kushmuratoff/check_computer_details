namespace WebApplication_11.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kalonka",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nomi = c.String(),
                        Narxi = c.String(),
                        KompaniyaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kompaniya", t => t.KompaniyaId)
                .Index(t => t.KompaniyaId);
            
            CreateTable(
                "dbo.Kompaniya",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nomi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Klaviatura",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nomi = c.String(),
                        Narxi = c.String(),
                        KompaniyaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kompaniya", t => t.KompaniyaId)
                .Index(t => t.KompaniyaId);
            
            CreateTable(
                "dbo.Yigish",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OpSistemaId = c.Int(),
                        XotiraId = c.Int(),
                        KalonkaId = c.Int(),
                        ProtsessorId = c.Int(),
                        KlaviaturaId = c.Int(),
                        ManitorId = c.Int(),
                        Summa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kalonka", t => t.KalonkaId)
                .ForeignKey("dbo.Klaviatura", t => t.KlaviaturaId)
                .ForeignKey("dbo.Manitor", t => t.ManitorId)
                .ForeignKey("dbo.OpSistema", t => t.OpSistemaId)
                .ForeignKey("dbo.Protsessor", t => t.ProtsessorId)
                .ForeignKey("dbo.Xotira", t => t.XotiraId)
                .Index(t => t.OpSistemaId)
                .Index(t => t.XotiraId)
                .Index(t => t.KalonkaId)
                .Index(t => t.ProtsessorId)
                .Index(t => t.KlaviaturaId)
                .Index(t => t.ManitorId);
            
            CreateTable(
                "dbo.Manitor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nomi = c.String(),
                        Narxi = c.String(),
                        KompaniyaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kompaniya", t => t.KompaniyaId)
                .Index(t => t.KompaniyaId);
            
            CreateTable(
                "dbo.OpSistema",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Turi = c.String(),
                        Raziryad = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Protsessor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nomi = c.String(),
                        Narxi = c.String(),
                        KompaniyaId = c.Int(),
                        OZUId = c.Int(),
                        VideoKartaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kompaniya", t => t.KompaniyaId)
                .ForeignKey("dbo.OZU", t => t.OZUId)
                .ForeignKey("dbo.VideoKarta", t => t.VideoKartaId)
                .Index(t => t.KompaniyaId)
                .Index(t => t.OZUId)
                .Index(t => t.VideoKartaId);
            
            CreateTable(
                "dbo.OZU",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Xajmi = c.String(),
                        Narxi = c.String(),
                        KompaniyaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kompaniya", t => t.KompaniyaId)
                .Index(t => t.KompaniyaId);
            
            CreateTable(
                "dbo.VideoKarta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nomi = c.String(),
                        Narxi = c.String(),
                        KompaniyaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kompaniya", t => t.KompaniyaId)
                .Index(t => t.KompaniyaId);
            
            CreateTable(
                "dbo.Xotira",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Xajmi = c.String(),
                        Narxi = c.String(),
                        KompaniyaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kompaniya", t => t.KompaniyaId)
                .Index(t => t.KompaniyaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Yigish", "XotiraId", "dbo.Xotira");
            DropForeignKey("dbo.Xotira", "KompaniyaId", "dbo.Kompaniya");
            DropForeignKey("dbo.Yigish", "ProtsessorId", "dbo.Protsessor");
            DropForeignKey("dbo.Protsessor", "VideoKartaId", "dbo.VideoKarta");
            DropForeignKey("dbo.VideoKarta", "KompaniyaId", "dbo.Kompaniya");
            DropForeignKey("dbo.Protsessor", "OZUId", "dbo.OZU");
            DropForeignKey("dbo.OZU", "KompaniyaId", "dbo.Kompaniya");
            DropForeignKey("dbo.Protsessor", "KompaniyaId", "dbo.Kompaniya");
            DropForeignKey("dbo.Yigish", "OpSistemaId", "dbo.OpSistema");
            DropForeignKey("dbo.Yigish", "ManitorId", "dbo.Manitor");
            DropForeignKey("dbo.Manitor", "KompaniyaId", "dbo.Kompaniya");
            DropForeignKey("dbo.Yigish", "KlaviaturaId", "dbo.Klaviatura");
            DropForeignKey("dbo.Yigish", "KalonkaId", "dbo.Kalonka");
            DropForeignKey("dbo.Klaviatura", "KompaniyaId", "dbo.Kompaniya");
            DropForeignKey("dbo.Kalonka", "KompaniyaId", "dbo.Kompaniya");
            DropIndex("dbo.Xotira", new[] { "KompaniyaId" });
            DropIndex("dbo.VideoKarta", new[] { "KompaniyaId" });
            DropIndex("dbo.OZU", new[] { "KompaniyaId" });
            DropIndex("dbo.Protsessor", new[] { "VideoKartaId" });
            DropIndex("dbo.Protsessor", new[] { "OZUId" });
            DropIndex("dbo.Protsessor", new[] { "KompaniyaId" });
            DropIndex("dbo.Manitor", new[] { "KompaniyaId" });
            DropIndex("dbo.Yigish", new[] { "ManitorId" });
            DropIndex("dbo.Yigish", new[] { "KlaviaturaId" });
            DropIndex("dbo.Yigish", new[] { "ProtsessorId" });
            DropIndex("dbo.Yigish", new[] { "KalonkaId" });
            DropIndex("dbo.Yigish", new[] { "XotiraId" });
            DropIndex("dbo.Yigish", new[] { "OpSistemaId" });
            DropIndex("dbo.Klaviatura", new[] { "KompaniyaId" });
            DropIndex("dbo.Kalonka", new[] { "KompaniyaId" });
            DropTable("dbo.Xotira");
            DropTable("dbo.VideoKarta");
            DropTable("dbo.OZU");
            DropTable("dbo.Protsessor");
            DropTable("dbo.OpSistema");
            DropTable("dbo.Manitor");
            DropTable("dbo.Yigish");
            DropTable("dbo.Klaviatura");
            DropTable("dbo.Kompaniya");
            DropTable("dbo.Kalonka");
        }
    }
}
