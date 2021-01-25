using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication_11.Models;

namespace WebApplication_11.Controllers
{
    public class FoydalanuvchiController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: /Foydalanuvchi/
        public ActionResult Index()
        {
            var foydalanuvchi = db.Foydalanuvchi.Include(f => f.Userlar);
            return View(foydalanuvchi.ToList());
        }

        // GET: /Foydalanuvchi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Foydalanuvchi foydalanuvchi = db.Foydalanuvchi.Find(id);
            if (foydalanuvchi == null)
            {
                return HttpNotFound();
            }
            return View(foydalanuvchi);
        }

        // GET: /Foydalanuvchi/Create
        public ActionResult Create()
        {
            ViewBag.UserlarId = new SelectList(db.Userlar, "Id", "Login");
            return View();
        }

        // POST: /Foydalanuvchi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,UserlarId,FISH,Uy_manzili,Tel_nomeri")] Foydalanuvchi foydalanuvchi)
        {
            if (ModelState.IsValid)
            {
                db.Foydalanuvchi.Add(foydalanuvchi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserlarId = new SelectList(db.Userlar, "Id", "Login", foydalanuvchi.UserlarId);
            return View(foydalanuvchi);
        }

        // GET: /Foydalanuvchi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Foydalanuvchi foydalanuvchi = db.Foydalanuvchi.Find(id);
            if (foydalanuvchi == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserlarId = new SelectList(db.Userlar, "Id", "Login", foydalanuvchi.UserlarId);
            return View(foydalanuvchi);
        }

        // POST: /Foydalanuvchi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,UserlarId,FISH,Uy_manzili,Tel_nomeri")] Foydalanuvchi foydalanuvchi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foydalanuvchi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserlarId = new SelectList(db.Userlar, "Id", "Login", foydalanuvchi.UserlarId);
            return View(foydalanuvchi);
        }

        // GET: /Foydalanuvchi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Foydalanuvchi foydalanuvchi = db.Foydalanuvchi.Find(id);
            if (foydalanuvchi == null)
            {
                return HttpNotFound();
            }
            return View(foydalanuvchi);
        }

        // POST: /Foydalanuvchi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Foydalanuvchi foydalanuvchi = db.Foydalanuvchi.Find(id);
            db.Foydalanuvchi.Remove(foydalanuvchi);
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
