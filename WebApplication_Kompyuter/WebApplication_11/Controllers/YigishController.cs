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

namespace WebApplication_11.Controllers
{
    public class YigishController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: /Yigish/
        public ActionResult Index()
        {
            var yigish = db.Yigish.Include(y => y.Blokpitaniya).Include(y => y.Qattiqdisk).Include(y => y.Onaplata).Include(y => y.Protsessor).Include(y => y.Kalonka).Include(y => y.OpSistema).Include(y => y.Kalonka).Include(y => y.Klaviatura).Include(y => y.Manitor).Include(y => y.Sichqoncha);
            return View(yigish.ToList());
        }

        // GET: /Yigish/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yigish yigish = db.Yigish.Find(id);
            if (yigish == null)
            {
                return HttpNotFound();
            }
            return View(yigish);
        }

        // GET: /Yigish/Create
        public ActionResult Create()
        {
            ViewBag.KalonkaId = new SelectList(db.Kalonka, "Id", "Nomi");
            ViewBag.KlaviaturaId = new SelectList(db.Klaviatura, "Id", "Nomi");
            ViewBag.ManitorId = new SelectList(db.Manitor, "Id", "Nomi");
            ViewBag.OpSistemaId = new SelectList(db.OpSistema, "Id", "Turi");
            ViewBag.ProtsessorId = new SelectList(db.Protsessor, "Id", "Nomi");
            ViewBag.XotiraId = new SelectList(db.Xotira, "Id", "Xajmi");
            return View();
        }

        // POST: /Yigish/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,OpSistemaId,XotiraId,KalonkaId,ProtsessorId,KlaviaturaId,ManitorId,Summa")] Yigish yigish)
        {
            if (ModelState.IsValid)
            {
                db.Yigish.Add(yigish);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KalonkaId = new SelectList(db.Kalonka, "Id", "Nomi", yigish.KalonkaId);
            ViewBag.KlaviaturaId = new SelectList(db.Klaviatura, "Id", "Nomi", yigish.KlaviaturaId);
            ViewBag.ManitorId = new SelectList(db.Manitor, "Id", "Nomi", yigish.ManitorId);
            ViewBag.OpSistemaId = new SelectList(db.OpSistema, "Id", "Turi", yigish.OpSistemaId);
            ViewBag.ProtsessorId = new SelectList(db.Protsessor, "Id", "Nomi", yigish.ProtsessorId);
            ViewBag.XotiraId = new SelectList(db.Xotira, "Id", "Xajmi", yigish.XotiraId);
            return View(yigish);
        }

        // GET: /Yigish/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yigish yigish = db.Yigish.Find(id);
            if (yigish == null)
            {
                return HttpNotFound();
            }
            ViewBag.KalonkaId = new SelectList(db.Kalonka, "Id", "Nomi", yigish.KalonkaId);
            ViewBag.KlaviaturaId = new SelectList(db.Klaviatura, "Id", "Nomi", yigish.KlaviaturaId);
            ViewBag.ManitorId = new SelectList(db.Manitor, "Id", "Nomi", yigish.ManitorId);
            ViewBag.OpSistemaId = new SelectList(db.OpSistema, "Id", "Turi", yigish.OpSistemaId);
            ViewBag.ProtsessorId = new SelectList(db.Protsessor, "Id", "Nomi", yigish.ProtsessorId);
            ViewBag.XotiraId = new SelectList(db.Xotira, "Id", "Xajmi", yigish.XotiraId);
            return View(yigish);
        }

        // POST: /Yigish/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,OpSistemaId,XotiraId,KalonkaId,ProtsessorId,KlaviaturaId,ManitorId,Summa")] Yigish yigish)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yigish).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KalonkaId = new SelectList(db.Kalonka, "Id", "Nomi", yigish.KalonkaId);
            ViewBag.KlaviaturaId = new SelectList(db.Klaviatura, "Id", "Nomi", yigish.KlaviaturaId);
            ViewBag.ManitorId = new SelectList(db.Manitor, "Id", "Nomi", yigish.ManitorId);
            ViewBag.OpSistemaId = new SelectList(db.OpSistema, "Id", "Turi", yigish.OpSistemaId);
            ViewBag.ProtsessorId = new SelectList(db.Protsessor, "Id", "Nomi", yigish.ProtsessorId);
            ViewBag.XotiraId = new SelectList(db.Xotira, "Id", "Xajmi", yigish.XotiraId);
            return View(yigish);
        }

        // GET: /Yigish/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yigish yigish = db.Yigish.Find(id);
            if (yigish == null)
            {
                return HttpNotFound();
            }
            return View(yigish);
        }

        // POST: /Yigish/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yigish yigish = db.Yigish.Find(id);
            db.Yigish.Remove(yigish);
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
