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
    public class OnaplataController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: /Onaplata/
        public ActionResult Index()
        {
            var onaplata = db.Onaplata.Include(o => o.Kompaniya);
            return View(onaplata.ToList());
        }

        // GET: /Onaplata/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Onaplata onaplata = db.Onaplata.Find(id);
            if (onaplata == null)
            {
                return HttpNotFound();
            }
            return View(onaplata);
        }

        // GET: /Onaplata/Create
        public ActionResult Create()
        {
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi");
            return View();
        }

        // POST: /Onaplata/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nomi,Narxi,Malumot,KompaniyaId,Onaplata_rasm")] Onaplata onaplata, HttpPostedFileBase Imagefile)
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
                    onaplata.Onaplata_rasm = filename;
                }
                db.Onaplata.Add(onaplata);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", onaplata.KompaniyaId);
            return View(onaplata);
        }

        // GET: /Onaplata/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Onaplata onaplata = db.Onaplata.Find(id);
            if (onaplata == null)
            {
                return HttpNotFound();
            }
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", onaplata.KompaniyaId);
            return View(onaplata);
        }

        // POST: /Onaplata/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nomi,Narxi,Malumot,KompaniyaId,Onaplata_rasm")] Onaplata onaplata)
        {
            if (ModelState.IsValid)
            {
                db.Entry(onaplata).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", onaplata.KompaniyaId);
            return View(onaplata);
        }

        // GET: /Onaplata/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Onaplata onaplata = db.Onaplata.Find(id);
            if (onaplata == null)
            {
                return HttpNotFound();
            }
            return View(onaplata);
        }

        // POST: /Onaplata/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Onaplata onaplata = db.Onaplata.Find(id);
            db.Onaplata.Remove(onaplata);
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
