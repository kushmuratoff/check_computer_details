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
    public class VideoKartaController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: /VideoKarta/
        public ActionResult Index(int? page8)
        {
            int pageSize = 2;
            int pageNumber = (page8 ?? 1);
            List<VideoKarta> docs = db.VideoKarta.Include(v => v.Kompaniya).ToList();
            return View(docs.ToPagedList(pageNumber, pageSize));
        }
        //public ActionResult Index()
        //{
        //    var videokarta = db.VideoKarta.Include(v => v.Kompaniya);
        //    return View(videokarta.ToList());
        //}

        // GET: /VideoKarta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoKarta videokarta = db.VideoKarta.Find(id);
            if (videokarta == null)
            {
                return HttpNotFound();
            }
            return View(videokarta);
        }

        // GET: /VideoKarta/Create
        public ActionResult Create()
        {
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi");
            return View();
        }

        // POST: /VideoKarta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nomi,Narxi,KompaniyaId,Video_rasm")] VideoKarta videokarta, HttpPostedFileBase Imagefile)
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
                    videokarta.Video_rasm = filename;
                }
                db.VideoKarta.Add(videokarta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", videokarta.KompaniyaId);
            return View(videokarta);
        }

        // GET: /VideoKarta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoKarta videokarta = db.VideoKarta.Find(id);
            if (videokarta == null)
            {
                return HttpNotFound();
            }
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", videokarta.KompaniyaId);
            return View(videokarta);
        }

        // POST: /VideoKarta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nomi,Narxi,KompaniyaId,Video_rasm")] VideoKarta videokarta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videokarta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", videokarta.KompaniyaId);
            return View(videokarta);
        }

        // GET: /VideoKarta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoKarta videokarta = db.VideoKarta.Find(id);
            if (videokarta == null)
            {
                return HttpNotFound();
            }
            return View(videokarta);
        }

        // POST: /VideoKarta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VideoKarta videokarta = db.VideoKarta.Find(id);
            db.VideoKarta.Remove(videokarta);
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
