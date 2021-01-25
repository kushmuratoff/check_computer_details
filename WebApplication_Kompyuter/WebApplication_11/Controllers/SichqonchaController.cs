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
    public class SichqonchaController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: /Sichqoncha/
        public ActionResult Index()
        {
            var sichqoncha = db.Sichqoncha.Include(s => s.Kompaniya);
            return View(sichqoncha.ToList());
        }

        // GET: /Sichqoncha/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sichqoncha sichqoncha = db.Sichqoncha.Find(id);
            if (sichqoncha == null)
            {
                return HttpNotFound();
            }
            return View(sichqoncha);
        }

        // GET: /Sichqoncha/Create
        public ActionResult Create()
        {
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi");
            return View();
        }

        // POST: /Sichqoncha/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nomi,Narxi,malumot,KompaniyaId,Sichqoncha_rasm")] Sichqoncha sichqoncha, HttpPostedFileBase Imagefile)
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
                    sichqoncha.Sichqoncha_rasm = filename;
                }
                db.Sichqoncha.Add(sichqoncha);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", sichqoncha.KompaniyaId);
            return View(sichqoncha);
        }

        // GET: /Sichqoncha/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sichqoncha sichqoncha = db.Sichqoncha.Find(id);
            if (sichqoncha == null)
            {
                return HttpNotFound();
            }
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", sichqoncha.KompaniyaId);
            return View(sichqoncha);
        }

        // POST: /Sichqoncha/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nomi,Narxi,malumot,KompaniyaId,Sichqoncha_rasm")] Sichqoncha sichqoncha)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sichqoncha).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", sichqoncha.KompaniyaId);
            return View(sichqoncha);
        }

        // GET: /Sichqoncha/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sichqoncha sichqoncha = db.Sichqoncha.Find(id);
            if (sichqoncha == null)
            {
                return HttpNotFound();
            }
            return View(sichqoncha);
        }

        // POST: /Sichqoncha/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sichqoncha sichqoncha = db.Sichqoncha.Find(id);
            db.Sichqoncha.Remove(sichqoncha);
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
