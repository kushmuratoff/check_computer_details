using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication_11.Models;
using System.IO;
using PagedList.Mvc;
using PagedList;
using System.Data.Entity;
using System.Web.Security;
using WebApplication_11.Models;

namespace WebApplication_11.Controllers
{
    public class HomeController : Controller
    {
        public BazaContext db = new BazaContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Register()
        {
            ViewBag.habar = "";
            return View();
        }
        [HttpPost]
        public ActionResult Register(string Login, string Parol)
        {

            Userlar user = null;
            user = db.Userlar.Where(u => u.Login == Login).FirstOrDefault();
            if (user != null)
            {
                ViewBag.habar = "Bunday foydalanuvchi mavjud";
                return View();
            }
            else
            {
                return RedirectToAction("Saqlash", "Home", new { Login = Login, Parol = Parol });
            }

        }
        public ActionResult Saqlash(string Login, string Parol)
        {
           // ViewBag.Tum = db.Tuman.ToList();
            ViewBag.Login = Login;
            ViewBag.Parol = Parol;
            return View();
        }
        [HttpPost]
        public ActionResult Saqlash(string Login, string Parol, string Fam, string UyManzil, string TelNom)
        {
            Userlar us = new Userlar();
            us.Login = Login;
            us.Password = Parol;
            us.RolesId = 2;
            db.Userlar.Add(us);
            db.SaveChanges();
            int idd = db.Userlar.Where(u => u.Login == Login).FirstOrDefault().Id;
            Foydalanuvchi fd = new Foydalanuvchi();
            fd.FISH = Fam;
            fd.Tel_nomeri = TelNom;
            fd.Uy_manzili = UyManzil;
            fd.UserlarId = idd;
            db.Foydalanuvchi.Add(fd);
            db.SaveChanges();
            
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Krish()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Krish(string Login, string Parol)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                Userlar user = null;
                using (BazaContext db = new BazaContext())
                {
                    user = db.Userlar.Where(u => u.Login == Login &&
                    u.Password == Parol).FirstOrDefault();
                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(Login, true);
                    var rolee = user.RolesId;
                    BazaContext db = new BazaContext();
                    var nomi = db.Roles.Where(r => r.Id == rolee).First().Nomi;
                    nomi = db.Userlar.Where(r => r.RolesId == rolee).FirstOrDefault().Login;
                    var useridd = user.Id;

                    switch (nomi)
                    {
                    case "Admin":
                    {
                    }break;
                case "User":
                    {
                        return RedirectToAction("Klient", "Admin", new { Id = db.Foydalanuvchi.Where(u => u.Userlar.Login == nomi).FirstOrDefault().Id });
                    }
                    break;
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Bunday foydalanuvchi mavjud emas");
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}