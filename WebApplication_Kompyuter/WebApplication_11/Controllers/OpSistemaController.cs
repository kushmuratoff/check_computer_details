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
    public class OpSistemaController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: /OpSistema/
        public ActionResult Index(int? page5)
        {
            int pageSize = 2;
            int pageNumber = (page5 ?? 1);
            List<OpSistema> docs = db.OpSistema.ToList();
            return View(docs.ToPagedList(pageNumber, pageSize));
        }
        //public ActionResult Index()
        //{
        //    return View(db.OpSistema.ToList());
        //}

        // GET: /OpSistema/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpSistema opsistema = db.OpSistema.Find(id);
            if (opsistema == null)
            {
                return HttpNotFound();
            }
            return View(opsistema);
        }

        // GET: /OpSistema/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /OpSistema/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Turi,Malumot,Raziryad")] OpSistema opsistema, HttpPostedFileBase Imagefile)
        {
            if (ModelState.IsValid)
            {
                if (Imagefile != null)
                {
                    string path = Server.MapPath("~/Image/");
                    if(!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string filename = Path.GetFileName(Imagefile.FileName);
                    Imagefile.SaveAs(path + Path.GetFileName(Imagefile.FileName));
                    opsistema.OS_rasm = filename;
                }
                
                db.OpSistema.Add(opsistema);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(opsistema);
        }

        // GET: /OpSistema/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpSistema opsistema = db.OpSistema.Find(id);
            if (opsistema == null)
            {
                return HttpNotFound();
            }
            return View(opsistema);
        }

        // POST: /OpSistema/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Turi,Raziryad,Malumot,OS_rasm")] OpSistema opsistema, HttpPostedFileBase Imagefile)
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
                    opsistema.OS_rasm = filename;
                }
                db.Entry(opsistema).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(opsistema);
        }

        // GET: /OpSistema/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpSistema opsistema = db.OpSistema.Find(id);
            if (opsistema == null)
            {
                return HttpNotFound();
            }
            return View(opsistema);
        }

        // POST: /OpSistema/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OpSistema opsistema = db.OpSistema.Find(id);
            db.OpSistema.Remove(opsistema);
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
