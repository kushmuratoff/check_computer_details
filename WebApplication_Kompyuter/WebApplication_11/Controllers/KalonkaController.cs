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
    public class KalonkaController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: /Kalonka/
        public ActionResult Index(int? page1)
        {
            int pageSize = 2;
            int pageNumber = (page1 ?? 1);
            List<Kalonka> docs = db.Kalonka.Include(k => k.Kompaniya).ToList();
            return View(docs.ToPagedList(pageNumber, pageSize));
        }
        //public ActionResult Index()
        //{
        //    var kalonka = db.Kalonka.Include(k => k.Kompaniya);
        //    return View(kalonka.ToList());
        //}

        // GET: /Kalonka/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kalonka kalonka = db.Kalonka.Find(id);
            if (kalonka == null)
            {
                return HttpNotFound();
            }
            return View(kalonka);
        }

        // GET: /Kalonka/Create
        public ActionResult Create()
        {
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi");
            return View();
        }

        // POST: /Kalonka/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nomi,Narxi,KompaniyaId,Malumot,Kalon_rasm")] Kalonka kalonka, HttpPostedFileBase Imagefile)
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
                    kalonka.Kalon_rasm = filename;
                }
                db.Kalonka.Add(kalonka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", kalonka.KompaniyaId);
            return View(kalonka);
        }

        // GET: /Kalonka/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kalonka kalonka = db.Kalonka.Find(id);
            if (kalonka == null)
            {
                return HttpNotFound();
            }
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", kalonka.KompaniyaId);
            return View(kalonka);
        }

        // POST: /Kalonka/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nomi,Narxi,KompaniyaId,Malumot,Kalon_rasm")] Kalonka kalonka, HttpPostedFileBase Imagefile)
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
                    kalonka.Kalon_rasm = filename;
                }
                db.Entry(kalonka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", kalonka.KompaniyaId);
            return View(kalonka);
        }

        // GET: /Kalonka/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kalonka kalonka = db.Kalonka.Find(id);
            if (kalonka == null)
            {
                return HttpNotFound();
            }
            return View(kalonka);
        }

        // POST: /Kalonka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kalonka kalonka = db.Kalonka.Find(id);
            db.Kalonka.Remove(kalonka);
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
