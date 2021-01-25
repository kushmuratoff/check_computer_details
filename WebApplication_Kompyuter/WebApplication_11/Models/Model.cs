using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication_11.Models
{
    public class Blokpitaniya
    {
        public int Id { get; set; }
        public string Nomi { get; set; }
        public string Narxi { get; set; }
        public string Malumot { get; set; }
        public int? KompaniyaId { get; set; }
        public Kompaniya Kompaniya { get; set; }
        public string Blokpitaniya_rasm { get; set; }
        public ICollection<Yigish> Yigishlar { get; set; }
    }
    public class Qattiqdisk
    {
        public int Id { get; set; }
        public string Nomi { get; set; }
        public string Narxi { get; set; }
        public string Malumot { get; set; }
        public int? KompaniyaId { get; set; }
        public Kompaniya Kompaniya { get; set; }
        public string Qattiqdisk_rasm { get; set; }
        public ICollection<Yigish> Yigishlar { get; set; }
    }
    public class Onaplata
    {
        public int Id { get; set; }
        public string Nomi { get; set; }
        public string Narxi { get; set; }
        public string Malumot { get; set; }
        public int? KompaniyaId { get; set; }
        public Kompaniya Kompaniya { get; set; }
        public string Onaplata_rasm { get; set; }

        public ICollection<Yigish> Yigishlar { get; set; }
    }
    public class Korpus
    {
        public int Id { get; set; }
        public string Nomi { get; set; }
        public string Narxi { get; set; }
        public string malumot { get; set; }
        public int? KompaniyaId { get; set; }
        public Kompaniya Kompaniya { get; set; }
        public string Korpus_rasm { get; set; }

        public ICollection<Yigish> Yigishlar { get; set; }
    }
    public class Sichqoncha
    {
        public int Id { get; set; }
        public string Nomi { get; set; }
        public string Narxi { get; set; }
        public string malumot { get; set; }
        public int? KompaniyaId { get; set; }
        public Kompaniya Kompaniya { get; set; }
        public string Sichqoncha_rasm { get; set; }

        public ICollection<Yigish> Yigishlar { get; set; }
    }
    public class Kompaniya
    {
        public int Id { get; set; }
        public string Nomi { get; set; }
        public string Malumot { get; set; }
        public string Komp_rasm { get; set; }
        public ICollection<Protsessor> Protsessorlar { get; set; }
        public ICollection<VideoKarta> VideoKartalar { get; set; }
        public ICollection<Xotira> Xotiralar { get; set; }
        public ICollection<Klaviatura> Klaviaturalar { get; set; }
        public ICollection<Manitor> Manitorlar { get; set; }
        public ICollection<Kalonka> Kalonkalar { get; set; }
        public ICollection<OZU> OZUlar { get; set; }
        public ICollection<Blokpitaniya> Blokpitaniyalar { get; set; }
        public ICollection<Qattiqdisk> Qattiqdisklae { get; set; }
        public ICollection<Onaplata> Onaplatalar { get; set; }
        public ICollection<Korpus> Korpuslar { get; set; }
        public ICollection<Sichqoncha> Sichqoncha { get; set; }
    }
    public class Protsessor
    {
        public int Id { get; set; }
        public string Nomi { get; set; }
        public string Narxi { get; set; }
        public string Malumot { get; set; }
        public int? KompaniyaId { get; set; }
        public Kompaniya Kompaniya { get; set; }
        public int? OZUId { get; set; }
        public OZU OZU { get; set; }
        public int? VideoKartaId { get; set; }
        public VideoKarta VideoKarta { get; set; }
        public string Prots_rasm { get; set; }
        public ICollection<Yigish> Yigishlar { get; set; }

    }
    public class VideoKarta
    {
        public int Id { get; set; }
        public string Nomi { get; set; }
        public string Narxi { get; set; }
        public string Malumot { get; set; }
        public int? KompaniyaId { get; set; }
        public Kompaniya Kompaniya { get; set; }
        public string Video_rasm { get; set; }

        public ICollection<Protsessor> Protsessorlar { get; set; }
    }
    public class OZU
    {
        public int Id { get; set; }
        public string Xajmi { get; set; }
        public string Narxi { get; set; }
        public string Malumot { get; set; }
        public int? KompaniyaId { get; set; }
        public Kompaniya Kompaniya { get; set; }
        public string OZU_rasm { get; set; }

        public ICollection<Protsessor> Protsessorlar { get; set; }

    }
    public class Xotira
    {
        public int Id { get; set; }
        public string Xajmi { get; set; }
        public string Narxi { get; set; }
        public string Malumot { get; set; }
        public int? KompaniyaId { get; set; }
        public Kompaniya Kompaniya { get; set; }
        public string Xotira_rasm { get; set; }

        public ICollection<Yigish> Yigishlar { get; set; }
    }
    public class Klaviatura
    {
        public int Id { get; set; }
        public string Nomi { get; set; }
        public string Narxi { get; set; }
        public string Malumot { get; set; }
        public int? KompaniyaId { get; set; }
        public Kompaniya Kompaniya { get; set; }
        public string Klav_rasm { get; set; }

        public ICollection<Yigish> Yigishlar { get; set; }
    }
    public class Manitor
    {
        public int Id { get; set; }
        public string Nomi { get; set; }
        public string Narxi { get; set; }
        public string Malumot { get; set; }
        public int? KompaniyaId { get; set; }
        public Kompaniya Kompaniya { get; set; }
        public string Mon_rasm { get; set; }

        public ICollection<Yigish> Yigishlar { get; set; }
    }
    public class OpSistema
    {
        public int Id { get; set; }
        public string Turi { get; set; }
        public string Raziryad { get; set; }
        public string Malumot { get; set; }
        public string OS_rasm { get; set; }
        public string Narxi { get; set; }

        public ICollection<Yigish> Yigishlar { get; set; }
    }
    public class Kalonka
    {
        public int Id { get; set; }
        public string Nomi { get; set; }
        public string Narxi { get; set; }
        public string Malumot { get; set; }
        public int? KompaniyaId { get; set; }
        public Kompaniya Kompaniya { get; set; }
        public string Kalon_rasm { get; set; }

        public ICollection<Yigish> Yigishlar { get; set; }
    }
    public class Yigish
    {
        public int Id { get; set; }
        public int? OpSistemaId { get; set; }
        public OpSistema OpSistema { get; set; }
        public int? XotiraId { get; set; }
        public Xotira Xotira { get; set; }
        public int? KalonkaId { get; set; }
        public Kalonka Kalonka { get; set; }
        public int? ProtsessorId { get; set; }
        public Protsessor Protsessor { get; set; }
        public int? KlaviaturaId { get; set; }
        public Klaviatura Klaviatura { get; set; }
        public int? ManitorId { get; set; }
        public Manitor Manitor { get; set; }
        public int? BlokpitaniyaId { get; set; }
        public Blokpitaniya Blokpitaniya { get; set; }
        public int? OnaplataId { get; set; }
        public Onaplata Onaplata { get; set; }
        public int? QattiqdiskId { get; set; }
        public Qattiqdisk Qattiqdisk { get; set; }
        public int? SichqonchaId { get; set; }
        public Sichqoncha Sichqoncha { get; set; }
        public int Summa { get; set; }
        public ICollection<Buyurtma> Buyurtmalar { get; set; }
    }
    public class Roles
    {
        public int Id { get; set; }
        public string Nomi { get; set; }
        public ICollection<Userlar> Userlarlar { get; set; }

    }
    public class Userlar
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int? RolesId { get; set; }
        public Roles Roles { get; set; }
       // public int? XaridorId { get; set; }
       // public Xaridor Xaridor { get; set; }
    }
    public class Foydalanuvchi
    {
        public int Id { get; set; }
        
        public int? UserlarId { get; set; }
        public Userlar Userlar { get; set; }
        public string FISH { get; set; }
        public string Uy_manzili { get; set; }
        public string Tel_nomeri { get; set; }
        public ICollection<Buyurtma> Buyurtmalar { get; set; }

    }
    public class Buyurtma
    {
        public int Id { get; set; }
        public int? FoydalanuvchiId { get; set; }
        public Foydalanuvchi Foydalanuvchi { get; set; }
        public int? YigishId { get; set; }
        public Yigish Yigish { get; set; }
        public string Holati { get; set; }
    }
}