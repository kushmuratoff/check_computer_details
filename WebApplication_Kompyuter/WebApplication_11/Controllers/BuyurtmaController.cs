using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication_11.Models;
using PagedList.Mvc;
using PagedList;

namespace WebApplication_11.Controllers
{
    public class BuyurtmaController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: /Buyurtma/
        public ActionResult Index(int? page)
        {
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            List<Buyurtma> docs = db.Buyurtma.Include(b => b.Foydalanuvchi).Include(b => b.Yigish).ToList();
            return View(docs.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Buyurtma()
        {
            if(User.Identity.IsAuthenticated)
            {
                return View();

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        //public ActionResult Index()
        //{
        //    var buyurtma = db.Buyurtma.Include(b => b.Foydalanuvchi).Include(b => b.Yigish);
        //    return View(buyurtma.ToList());
        //}

        // GET: /Buyurtma/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buyurtma buyurtma = db.Buyurtma.Find(id);
            if (buyurtma == null)
            {
                return HttpNotFound();
            }
            return View(buyurtma);
        }

        // GET: /Buyurtma/Create
        public ActionResult Create()
        {
            ViewBag.FoydalanuvchiId = new SelectList(db.Foydalanuvchi, "Id", "Login");
            ViewBag.YigishId = new SelectList(db.Yigish, "Id", "Id");
            return View();
        }

        // POST: /Buyurtma/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,FoydalanuvchiId,YigishId,Holati")] Buyurtma buyurtma)
        {
            if (ModelState.IsValid)
            {
                db.Buyurtma.Add(buyurtma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FoydalanuvchiId = new SelectList(db.Foydalanuvchi, "Id", "Login", buyurtma.FoydalanuvchiId);
            ViewBag.YigishId = new SelectList(db.Yigish, "Id", "Id", buyurtma.YigishId);
            return View(buyurtma);
        }

        // GET: /Buyurtma/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buyurtma buyurtma = db.Buyurtma.Find(id);
            if (buyurtma == null)
            {
                return HttpNotFound();
            }
            ViewBag.FoydalanuvchiId = new SelectList(db.Foydalanuvchi, "Id", "Login", buyurtma.FoydalanuvchiId);
            ViewBag.YigishId = new SelectList(db.Yigish, "Id", "Id", buyurtma.YigishId);
            return View(buyurtma);
        }

        // POST: /Buyurtma/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,FoydalanuvchiId,YigishId,Holati")] Buyurtma buyurtma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buyurtma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FoydalanuvchiId = new SelectList(db.Foydalanuvchi, "Id", "Login", buyurtma.FoydalanuvchiId);
            ViewBag.YigishId = new SelectList(db.Yigish, "Id", "Id", buyurtma.YigishId);
            return View(buyurtma);
        }

        // GET: /Buyurtma/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buyurtma buyurtma = db.Buyurtma.Find(id);
            if (buyurtma == null)
            {
                return HttpNotFound();
            }
            return View(buyurtma);
        }

        // POST: /Buyurtma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Buyurtma buyurtma = db.Buyurtma.Find(id);
            db.Buyurtma.Remove(buyurtma);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
