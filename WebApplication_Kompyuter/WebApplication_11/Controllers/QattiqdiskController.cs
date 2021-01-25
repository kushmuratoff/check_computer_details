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
    public class QattiqdiskController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: /Qattiqdisk/
        public ActionResult Index()
        {
            var qattiqdisk = db.Qattiqdisk.Include(q => q.Kompaniya);
            return View(qattiqdisk.ToList());
        }

        // GET: /Qattiqdisk/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qattiqdisk qattiqdisk = db.Qattiqdisk.Find(id);
            if (qattiqdisk == null)
            {
                return HttpNotFound();
            }
            return View(qattiqdisk);
        }

        // GET: /Qattiqdisk/Create
        public ActionResult Create()
        {
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi");
            return View();
        }

        // POST: /Qattiqdisk/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nomi,Narxi,Malumot,KompaniyaId,Qattiqdisk_rasm")] Qattiqdisk qattiqdisk, HttpPostedFileBase Imagefile)
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
                    qattiqdisk.Qattiqdisk_rasm = filename;
                }
                db.Qattiqdisk.Add(qattiqdisk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", qattiqdisk.KompaniyaId);
            return View(qattiqdisk);
        }

        // GET: /Qattiqdisk/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qattiqdisk qattiqdisk = db.Qattiqdisk.Find(id);
            if (qattiqdisk == null)
            {
                return HttpNotFound();
            }
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", qattiqdisk.KompaniyaId);
            return View(qattiqdisk);
        }

        // POST: /Qattiqdisk/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nomi,Narxi,Malumot,KompaniyaId,Qattiqdisk_rasm")] Qattiqdisk qattiqdisk)
        {
            if (ModelState.IsValid)
            {

                db.Entry(qattiqdisk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KompaniyaId = new SelectList(db.Kompaniya, "Id", "Nomi", qattiqdisk.KompaniyaId);
            return View(qattiqdisk);
        }

        // GET: /Qattiqdisk/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qattiqdisk qattiqdisk = db.Qattiqdisk.Find(id);
            if (qattiqdisk == null)
            {
                return HttpNotFound();
            }
            return View(qattiqdisk);
        }

        // POST: /Qattiqdisk/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Qattiqdisk qattiqdisk = db.Qattiqdisk.Find(id);
            db.Qattiqdisk.Remove(qattiqdisk);
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
