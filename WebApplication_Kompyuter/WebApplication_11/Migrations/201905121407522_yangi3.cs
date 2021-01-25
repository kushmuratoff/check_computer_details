namespace WebApplication_11.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yangi3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blokpitaniya",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nomi = c.String(),
                        Narxi = c.String(),
                        Malumot = c.String(),
                        KompaniyaId = c.Int(),
                        Blokpitaniya_rasm = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kompaniya", t => t.KompaniyaId)
                .Index(t => t.KompaniyaId);
            
            CreateTable(
                "dbo.Onaplata",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nomi = c.String(),
                        Narxi = c.String(),
                        Malumot = c.String(),
                        KompaniyaId = c.Int(),
                        Onaplata_rasm = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kompaniya", t => t.KompaniyaId)
                .Index(t => t.KompaniyaId);
            
            CreateTable(
                "dbo.Qattiqdisk",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nomi = c.String(),
                        Narxi = c.String(),
                        Malumot = c.String(),
                        KompaniyaId = c.Int(),
                        Qattiqdisk_rasm = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kompaniya", t => t.KompaniyaId)
                .Index(t => t.KompaniyaId);
            
            CreateTable(
                "dbo.Sichqoncha",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nomi = c.String(),
                        Narxi = c.String(),
                        malumot = c.String(),
                        KompaniyaId = c.Int(),
                        Sichqoncha_rasm = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kompaniya", t => t.KompaniyaId)
                .Index(t => t.KompaniyaId);
            
            CreateTable(
                "dbo.Korpus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nomi = c.String(),
                        Narxi = c.String(),
                        malumot = c.String(),
                        KompaniyaId = c.Int(),
                        Korpus_rasm = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kompaniya", t => t.KompaniyaId)
                .Index(t => t.KompaniyaId);
            
            AddColumn("dbo.Yigish", "BlokpitaniyaId", c => c.Int());
            AddColumn("dbo.Yigish", "OnaplataId", c => c.Int());
            AddColumn("dbo.Yigish", "QattiqdiskId", c => c.Int());
            AddColumn("dbo.Yigish", "SichqonchaId", c => c.Int());
            AddColumn("dbo.Yigish", "Korpus_Id", c => c.Int());
            AddColumn("dbo.Kalonka", "Malumot", c => c.String());
            AddColumn("dbo.Kompaniya", "Malumot", c => c.String());
            AddColumn("dbo.Klaviatura", "Malumot", c => c.String());
            AddColumn("dbo.Manitor", "Malumot", c => c.String());
            AddColumn("dbo.OZU", "Malumot", c => c.String());
            AddColumn("dbo.Protsessor", "Malumot", c => c.String());
            AddColumn("dbo.VideoKarta", "Malumot", c => c.String());
            AddColumn("dbo.Xotira", "Malumot", c => c.String());
            AddColumn("dbo.OpSistema", "Malumot", c => c.String());
            CreateIndex("dbo.Yigish", "BlokpitaniyaId");
            CreateIndex("dbo.Yigish", "OnaplataId");
            CreateIndex("dbo.Yigish", "QattiqdiskId");
            CreateIndex("dbo.Yigish", "SichqonchaId");
            CreateIndex("dbo.Yigish", "Korpus_Id");
            AddForeignKey("dbo.Yigish", "BlokpitaniyaId", "dbo.Blokpitaniya", "Id");
            AddForeignKey("dbo.Yigish", "OnaplataId", "dbo.Onaplata", "Id");
            AddForeignKey("dbo.Yigish", "QattiqdiskId", "dbo.Qattiqdisk", "Id");
            AddForeignKey("dbo.Yigish", "SichqonchaId", "dbo.Sichqoncha", "Id");
            AddForeignKey("dbo.Yigish", "Korpus_Id", "dbo.Korpus", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Yigish", "Korpus_Id", "dbo.Korpus");
            DropForeignKey("dbo.Korpus", "KompaniyaId", "dbo.Kompaniya");
            DropForeignKey("dbo.Yigish", "SichqonchaId", "dbo.Sichqoncha");
            DropForeignKey("dbo.Sichqoncha", "KompaniyaId", "dbo.Kompaniya");
            DropForeignKey("dbo.Yigish", "QattiqdiskId", "dbo.Qattiqdisk");
            DropForeignKey("dbo.Qattiqdisk", "KompaniyaId", "dbo.Kompaniya");
            DropForeignKey("dbo.Yigish", "OnaplataId", "dbo.Onaplata");
            DropForeignKey("dbo.Onaplata", "KompaniyaId", "dbo.Kompaniya");
            DropForeignKey("dbo.Yigish", "BlokpitaniyaId", "dbo.Blokpitaniya");
            DropForeignKey("dbo.Blokpitaniya", "KompaniyaId", "dbo.Kompaniya");
            DropIndex("dbo.Korpus", new[] { "KompaniyaId" });
            DropIndex("dbo.Sichqoncha", new[] { "KompaniyaId" });
            DropIndex("dbo.Qattiqdisk", new[] { "KompaniyaId" });
            DropIndex("dbo.Onaplata", new[] { "KompaniyaId" });
            DropIndex("dbo.Yigish", new[] { "Korpus_Id" });
            DropIndex("dbo.Yigish", new[] { "SichqonchaId" });
            DropIndex("dbo.Yigish", new[] { "QattiqdiskId" });
            DropIndex("dbo.Yigish", new[] { "OnaplataId" });
            DropIndex("dbo.Yigish", new[] { "BlokpitaniyaId" });
            DropIndex("dbo.Blokpitaniya", new[] { "KompaniyaId" });
            DropColumn("dbo.OpSistema", "Malumot");
            DropColumn("dbo.Xotira", "Malumot");
            DropColumn("dbo.VideoKarta", "Malumot");
            DropColumn("dbo.Protsessor", "Malumot");
            DropColumn("dbo.OZU", "Malumot");
            DropColumn("dbo.Manitor", "Malumot");
            DropColumn("dbo.Klaviatura", "Malumot");
            DropColumn("dbo.Kompaniya", "Malumot");
            DropColumn("dbo.Kalonka", "Malumot");
            DropColumn("dbo.Yigish", "Korpus_Id");
            DropColumn("dbo.Yigish", "SichqonchaId");
            DropColumn("dbo.Yigish", "QattiqdiskId");
            DropColumn("dbo.Yigish", "OnaplataId");
            DropColumn("dbo.Yigish", "BlokpitaniyaId");
            DropTable("dbo.Korpus");
            DropTable("dbo.Sichqoncha");
            DropTable("dbo.Qattiqdisk");
            DropTable("dbo.Onaplata");
            DropTable("dbo.Blokpitaniya");
        }
    }
}
