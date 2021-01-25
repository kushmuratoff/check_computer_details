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

namespace WebApplication_11.Controllers
{
    public class BlokpitaniyaController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: /Blokpitaniya/
        public ActionResult Index()
        {
            var blokpitaniya = db.Blokpitaniya.Include(b => b.Kompaniya);
            return View(blokpitaniya.ToList());
        }

        // GET: /Blokpitaniya/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blokpitaniya blokpitaniya = db.Blokpitaniya.Find(id);
            if (blokpitaniya == null)
            {
                return HttpNotFound();
            }
            return View(blokpitaniya);
        }

        // GET: /Blokpitaniya/Create
        public ActionResult Create()
        {
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi");
            return View();
        }

        // POST: /Blokpitaniya/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nomi,Narxi,Malumot,KompaniyaId,Blokpitaniya_rasm")] Blokpitaniya blokpitaniya, HttpPostedFileBase Imagefile)
        {
            if (ModelState.IsValid)
            {
                if (Imagefile != null)
                {
                    string path = Server.MapPath("~/Image/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string filename = Path.GetFileName(Imagefile.FileName);
                    Imagefile.SaveAs(path + Path.GetFileName(Imagefile.FileName));
                    blokpitaniya.Blokpitaniya_rasm = filename;
                }
                db.Blokpitaniya.Add(blokpitaniya);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", blokpitaniya.KompaniyaId);
            return View(blokpitaniya);
        }

        // GET: /Blokpitaniya/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blokpitaniya blokpitaniya = db.Blokpitaniya.Find(id);
            if (blokpitaniya == null)
            {
                return HttpNotFound();
            }
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", blokpitaniya.KompaniyaId);
            return View(blokpitaniya);
        }

        // POST: /Blokpitaniya/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nomi,Narxi,Malumot,KompaniyaId,Blokpitaniya_rasm")] Blokpitaniya blokpitaniya)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blokpitaniya).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", blokpitaniya.KompaniyaId);
            return View(blokpitaniya);
        }

        // GET: /Blokpitaniya/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blokpitaniya blokpitaniya = db.Blokpitaniya.Find(id);
            if (blokpitaniya == null)
            {
                return HttpNotFound();
            }
            return View(blokpitaniya);
        }

        // POST: /Blokpitaniya/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blokpitaniya blokpitaniya = db.Blokpitaniya.Find(id);
            db.Blokpitaniya.Remove(blokpitaniya);
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
