using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication_11.Models;
namespace WebApplication_11.Models
{
    public class BazaContext : DbContext
    {
        public DbSet<Kompaniya> Kompaniya { get; set; }
        public DbSet<Protsessor> Protsessor { get; set; }
        public DbSet<VideoKarta> VideoKarta { get; set; }
        public DbSet<Xotira> Xotira { get; set; }
        public DbSet<Manitor> Manitor { get; set; }
        public DbSet<Klaviatura> Klaviatura { get; set; }
        public DbSet<OpSistema> OpSistema { get; set; }
        public DbSet<Kalonka> Kalonka { get; set; }
        public DbSet<OZU> OZU { get; set; }
        public DbSet<Yigish> Yigish { get; set; }
        public DbSet<Buyurtma> Buyurtma { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Foydalanuvchi> Foydalanuvchi { get; set; }
        public DbSet<Userlar> Userlar { get; set; }
        public DbSet<Blokpitaniya> Blokpitaniya { get; set; }
        public DbSet<Qattiqdisk> Qattiqdisk { get; set; }
        public DbSet<Onaplata> Onaplata { get; set; }
        public DbSet<Korpus> Korpus { get; set; }
        public DbSet<Sichqoncha> Sichqoncha { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

       
    }
    public class BazaInit : CreateDatabaseIfNotExists<BazaContext>
    {
        protected override void Seed(BazaContext context)
        {
            context.Kompaniya.Add(new Kompaniya { Nomi = "Intel" });
            base.Seed(context);
        }
    }
}