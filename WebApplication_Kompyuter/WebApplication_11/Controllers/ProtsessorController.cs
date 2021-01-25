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
    public class ProtsessorController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: /Protsessor/
        public ActionResult Index(int? page7)
        {
            int pageSize = 2;
            int pageNumber = (page7 ?? 1);
            List<Protsessor> docs = db.Protsessor.Include(k => k.Kompaniya).Include(p => p.OZU).Include(p => p.VideoKarta).ToList();
            return View(docs.ToPagedList(pageNumber, pageSize));
        }
        //public ActionResult Index()
        //{
        //    var protsessor = db.Protsessor.Include(p => p.Kompaniya).Include(p => p.OZU).Include(p => p.VideoKarta);
        //    return View(protsessor.ToList());
        //}

        // GET: /Protsessor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Protsessor protsessor = db.Protsessor.Find(id);
            if (protsessor == null)
            {
                return HttpNotFound();
            }
            return View(protsessor);
        }

        // GET: /Protsessor/Create
        public ActionResult Create()
        {
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi");
            ViewBag.OZUId = new SelectList(db.OZU, "Id", "Xajmi");
            ViewBag.VideoKartaId = new SelectList(db.VideoKarta, "Id", "Nomi");
            return View();
        }

        // POST: /Protsessor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nomi,Narxi,KompaniyaId,OZUId,VideoKartaId,Prots_rasm")] Protsessor protsessor, HttpPostedFileBase Imagefile)
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
                    protsessor.Prots_rasm = filename;
                }
                db.Protsessor.Add(protsessor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", protsessor.KompaniyaId);
            ViewBag.OZUId = new SelectList(db.OZU, "Id", "Xajmi", protsessor.OZUId);
            ViewBag.VideoKartaId = new SelectList(db.VideoKarta, "Id", "Nomi", protsessor.VideoKartaId);
            return View(protsessor);
        }

        // GET: /Protsessor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Protsessor protsessor = db.Protsessor.Find(id);
            if (protsessor == null)
            {
                return HttpNotFound();
            }
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", protsessor.KompaniyaId);
            ViewBag.OZUId = new SelectList(db.OZU, "Id", "Xajmi", protsessor.OZUId);
            ViewBag.VideoKartaId = new SelectList(db.VideoKarta, "Id", "Nomi", protsessor.VideoKartaId);
            return View(protsessor);
        }

        // POST: /Protsessor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nomi,Narxi,KompaniyaId,OZUId,VideoKartaId,Prots_rasm")] Protsessor protsessor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(protsessor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", protsessor.KompaniyaId);
            ViewBag.OZUId = new SelectList(db.OZU, "Id", "Xajmi", protsessor.OZUId);
            ViewBag.VideoKartaId = new SelectList(db.VideoKarta, "Id", "Nomi", protsessor.VideoKartaId);
            return View(protsessor);
        }

        // GET: /Protsessor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Protsessor protsessor = db.Protsessor.Find(id);
            if (protsessor == null)
            {
                return HttpNotFound();
            }
            return View(protsessor);
        }

        // POST: /Protsessor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Protsessor protsessor = db.Protsessor.Find(id);
            db.Protsessor.Remove(protsessor);
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
