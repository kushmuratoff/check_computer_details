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
    public class XotiraController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: /Xotira/
        public ActionResult Index(int? page9)
        {
            int pageSize = 2;
            int pageNumber = (page9 ?? 1);
            List<Xotira> docs = db.Xotira.Include(v => v.Kompaniya).ToList();
            return View(docs.ToPagedList(pageNumber, pageSize));
        }
        //public ActionResult Index()
        //{
        //    var xotira = db.Xotira.Include(x => x.Kompaniya);
        //    return View(xotira.ToList());
        //}

        // GET: /Xotira/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Xotira xotira = db.Xotira.Find(id);
            if (xotira == null)
            {
                return HttpNotFound();
            }
            return View(xotira);
        }

        // GET: /Xotira/Create
        public ActionResult Create()
        {
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi");
            return View();
        }

        // POST: /Xotira/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Xajmi,Narxi,KompaniyaId,Xotira_rasm")] Xotira xotira, HttpPostedFileBase Imagefile)
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
                    xotira.Xotira_rasm = filename;
                }
                db.Xotira.Add(xotira);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", xotira.KompaniyaId);
            return View(xotira);
        }

        // GET: /Xotira/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Xotira xotira = db.Xotira.Find(id);
            if (xotira == null)
            {
                return HttpNotFound();
            }
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", xotira.KompaniyaId);
            return View(xotira);
        }

        // POST: /Xotira/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Xajmi,Narxi,KompaniyaId,Xotira_rasm")] Xotira xotira)
        {
            if (ModelState.IsValid)
            {
                db.Entry(xotira).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", xotira.KompaniyaId);
            return View(xotira);
        }

        // GET: /Xotira/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Xotira xotira = db.Xotira.Find(id);
            if (xotira == null)
            {
                return HttpNotFound();
            }
            return View(xotira);
        }

        // POST: /Xotira/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Xotira xotira = db.Xotira.Find(id);
            db.Xotira.Remove(xotira);
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
