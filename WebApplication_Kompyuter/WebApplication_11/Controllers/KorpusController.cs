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
    public class KorpusController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: /Korpus/
        public ActionResult Index()
        {
            var korpus = db.Korpus.Include(k => k.Kompaniya);
            return View(korpus.ToList());
        }

        // GET: /Korpus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korpus korpus = db.Korpus.Find(id);
            if (korpus == null)
            {
                return HttpNotFound();
            }
            return View(korpus);
        }

        // GET: /Korpus/Create
        public ActionResult Create()
        {
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi");
            return View();
        }

        // POST: /Korpus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nomi,Narxi,malumot,KompaniyaId,Korpus_rasm")] Korpus korpus, HttpPostedFileBase Imagefile)
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
                    korpus.Korpus_rasm = filename;
                }
                db.Korpus.Add(korpus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", korpus.KompaniyaId);
            return View(korpus);
        }

        // GET: /Korpus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korpus korpus = db.Korpus.Find(id);
            if (korpus == null)
            {
                return HttpNotFound();
            }
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", korpus.KompaniyaId);
            return View(korpus);
        }

        // POST: /Korpus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nomi,Narxi,malumot,KompaniyaId,Korpus_rasm")] Korpus korpus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(korpus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", korpus.KompaniyaId);
            return View(korpus);
        }

        // GET: /Korpus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korpus korpus = db.Korpus.Find(id);
            if (korpus == null)
            {
                return HttpNotFound();
            }
            return View(korpus);
        }

        // POST: /Korpus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Korpus korpus = db.Korpus.Find(id);
            db.Korpus.Remove(korpus);
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
