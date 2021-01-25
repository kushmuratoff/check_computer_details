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
    public class OZUController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: /OZU/
        public ActionResult Index(int? page6)
        {
            int pageSize = 2;
            int pageNumber = (page6 ?? 1);
            List<OZU> docs = db.OZU.Include(k => k.Kompaniya).ToList();
            return View(docs.ToPagedList(pageNumber, pageSize));
        }
        //public ActionResult Index()
        //{
        //    var ozu = db.OZU.Include(o => o.Kompaniya);
        //    return View(ozu.ToList());
        //}

        // GET: /OZU/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OZU ozu = db.OZU.Find(id);
            if (ozu == null)
            {
                return HttpNotFound();
            }
            return View(ozu);
        }

        // GET: /OZU/Create
        public ActionResult Create()
        {
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi");
            return View();
        }

        // POST: /OZU/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Xajmi,Narxi,KompaniyaId,OZU_rasm")] OZU ozu, HttpPostedFileBase Imagefile)
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
                    ozu.OZU_rasm = filename;
                }
                db.OZU.Add(ozu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", ozu.KompaniyaId);
            return View(ozu);
        }

        // GET: /OZU/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OZU ozu = db.OZU.Find(id);
            if (ozu == null)
            {
                return HttpNotFound();
            }
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", ozu.KompaniyaId);
            return View(ozu);
        }

        // POST: /OZU/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Xajmi,Narxi,KompaniyaId,OZU_rasm")] OZU ozu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ozu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", ozu.KompaniyaId);
            return View(ozu);
        }

        // GET: /OZU/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OZU ozu = db.OZU.Find(id);
            if (ozu == null)
            {
                return HttpNotFound();
            }
            return View(ozu);
        }

        // POST: /OZU/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OZU ozu = db.OZU.Find(id);
            db.OZU.Remove(ozu);
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
