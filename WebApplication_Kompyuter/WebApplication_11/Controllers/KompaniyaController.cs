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
    public class KompaniyaController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: /Kompaniya/
        public ActionResult Index(int? page3)
        {
            int pageSize = 2;
            int pageNumber = (page3 ?? 1);
            List<Kompaniya> docs = db.Kompaniya.ToList();
            return View(docs.ToPagedList(pageNumber, pageSize));
        }
        //public ActionResult Index()
        //{
        //    return View(db.Kompaniya.ToList());
        //}

        // GET: /Kompaniya/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kompaniya kompaniya = db.Kompaniya.Find(id);
            if (kompaniya == null)
            {
                return HttpNotFound();
            }
            return View(kompaniya);
        }

        // GET: /Kompaniya/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Kompaniya/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nomi,Komp_rasm")] Kompaniya kompaniya, HttpPostedFileBase Imagefile)
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
                    kompaniya.Komp_rasm = filename;
                }
                db.Kompaniya.Add(kompaniya);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kompaniya);
        }

        // GET: /Kompaniya/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kompaniya kompaniya = db.Kompaniya.Find(id);
            if (kompaniya == null)
            {
                return HttpNotFound();
            }
            return View(kompaniya);
        }

        // POST: /Kompaniya/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nomi,Komp_rasm")] Kompaniya kompaniya)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kompaniya).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kompaniya);
        }

        // GET: /Kompaniya/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kompaniya kompaniya = db.Kompaniya.Find(id);
            if (kompaniya == null)
            {
                return HttpNotFound();
            }
            return View(kompaniya);
        }

        // POST: /Kompaniya/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kompaniya kompaniya = db.Kompaniya.Find(id);
            db.Kompaniya.Remove(kompaniya);
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
