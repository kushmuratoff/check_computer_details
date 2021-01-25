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
    public class KlaviaturaController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: /Klaviatura/
        public ActionResult Index(int? page2)
        {
            int pageSize = 2;
            int pageNumber = (page2 ?? 1);
            List<Klaviatura> docs = db.Klaviatura.Include(k => k.Kompaniya).ToList();
            return View(docs.ToPagedList(pageNumber, pageSize));
        }
        //public ActionResult Index()
        //{
        //    var klaviatura = db.Klaviatura.Include(k => k.Kompaniya);
        //    return View(klaviatura.ToList());
        //}

        // GET: /Klaviatura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klaviatura klaviatura = db.Klaviatura.Find(id);
            if (klaviatura == null)
            {
                return HttpNotFound();
            }
            return View(klaviatura);
        }

        // GET: /Klaviatura/Create
        public ActionResult Create()
        {
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi");
            return View();
        }

        // POST: /Klaviatura/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nomi,Narxi,Malumot,KompaniyaId,Klav_rasm")] Klaviatura klaviatura, HttpPostedFileBase Imagefile)
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
                    klaviatura.Klav_rasm = filename;
                }
                db.Klaviatura.Add(klaviatura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", klaviatura.KompaniyaId);
            return View(klaviatura);
        }

        // GET: /Klaviatura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klaviatura klaviatura = db.Klaviatura.Find(id);
            if (klaviatura == null)
            {
                return HttpNotFound();
            }
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", klaviatura.KompaniyaId);
            return View(klaviatura);
        }

        // POST: /Klaviatura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nomi,Narxi,KompaniyaId,Malumot,Klav_rasm")] Klaviatura klaviatura, HttpPostedFileBase Imagefile)
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
                    klaviatura.Klav_rasm = filename;
                }
                db.Entry(klaviatura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", klaviatura.KompaniyaId);
            return View(klaviatura);
        }

        // GET: /Klaviatura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klaviatura klaviatura = db.Klaviatura.Find(id);
            if (klaviatura == null)
            {
                return HttpNotFound();
            }
            return View(klaviatura);
        }

        // POST: /Klaviatura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Klaviatura klaviatura = db.Klaviatura.Find(id);
            db.Klaviatura.Remove(klaviatura);
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
