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
    public class ManitorController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: /Manitor/
        public ActionResult Index(int? page4)
        {
            int pageSize = 2;
            int pageNumber = (page4 ?? 1);
            List<Manitor> docs = db.Manitor.Include(k => k.Kompaniya).ToList();
            return View(docs.ToPagedList(pageNumber, pageSize));
        }
        //public ActionResult Index()
        //{
        //    var manitor = db.Manitor.Include(m => m.Kompaniya);
        //    return View(manitor.ToList());
        //}

        // GET: /Manitor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manitor manitor = db.Manitor.Find(id);
            if (manitor == null)
            {
                return HttpNotFound();
            }
            return View(manitor);
        }

        // GET: /Manitor/Create
        public ActionResult Create()
        {
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi");
            return View();
        }

        // POST: /Manitor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nomi,Narxi,KompaniyaId,Mon_rasm")] Manitor manitor, HttpPostedFileBase Imagefile)
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
                    manitor.Mon_rasm = filename;
                }
                db.Manitor.Add(manitor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", manitor.KompaniyaId);
            return View(manitor);
        }

        // GET: /Manitor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manitor manitor = db.Manitor.Find(id);
            if (manitor == null)
            {
                return HttpNotFound();
            }
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", manitor.KompaniyaId);
            return View(manitor);
        }

        // POST: /Manitor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nomi,Narxi,KompaniyaId,Malumot,Mon_rasm")] Manitor manitor, HttpPostedFileBase Imagefile)
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
                    manitor.Mon_rasm = filename;
                }
                db.Entry(manitor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", manitor.KompaniyaId);
            return View(manitor);
        }

        // GET: /Manitor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manitor manitor = db.Manitor.Find(id);
            if (manitor == null)
            {
                return HttpNotFound();
            }
            return View(manitor);
        }

        // POST: /Manitor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manitor manitor = db.Manitor.Find(id);
            db.Manitor.Remove(manitor);
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
