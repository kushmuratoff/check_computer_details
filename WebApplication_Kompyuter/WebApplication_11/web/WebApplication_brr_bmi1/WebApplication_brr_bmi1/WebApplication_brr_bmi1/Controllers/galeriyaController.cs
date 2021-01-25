using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebApplication_brr_bmi1.Models;
using PagedList.Mvc;
using PagedList;

namespace WebApplication_brr_bmi1.Controllers
{
    public class galeriyaController : Controller
    {
        //
        // GET: /galeriya/
        private BazaContext db = new BazaContext();

        // GET: /Xonadon/
        public ActionResult Index()
        {
            Sahifa s = new Sahifa();
            s.Xonadon = db.Xonadon.Include(x => x.Uy).Include(x => x.Uy.Tuman).Include(x => x.Uy.Tuman.Viloyat).Where(x => x.UyId != null).ToList();
            // var xonadon = db.Xonadon.Include(x => x.Uy);
            return View(s);
        }
      
        public ActionResult Buy()
        {
            if(!User.Identity.IsAuthenticated)
            {
                ViewBag.Habar = "Siz ro'yhatdan o'tmagansiz!!";
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View();
        }
	}
}