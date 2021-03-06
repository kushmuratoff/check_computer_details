﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication_11.Models;

namespace WebApplication_11.Controllers
{
    public class UserlarController : Controller
    {
        private BazaContext db = new BazaContext();

        // GET: /Userlar/
        public ActionResult Index()
        {
            var userlar = db.Userlar.Include(u => u.Roles);
            return View(userlar.ToList());
        }

        // GET: /Userlar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userlar userlar = db.Userlar.Find(id);
            if (userlar == null)
            {
                return HttpNotFound();
            }
            return View(userlar);
        }

        // GET: /Userlar/Create
        public ActionResult Create()
        {
            ViewBag.RolesId = new SelectList(db.Roles, "Id", "Nomi");
            return View();
        }

        // POST: /Userlar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Login,Password,RolesId")] Userlar userlar)
        {
            if (ModelState.IsValid)
            {
                db.Userlar.Add(userlar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RolesId = new SelectList(db.Roles, "Id", "Nomi", userlar.RolesId);
            return View(userlar);
        }

        // GET: /Userlar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userlar userlar = db.Userlar.Find(id);
            if (userlar == null)
            {
                return HttpNotFound();
            }
            ViewBag.RolesId = new SelectList(db.Roles, "Id", "Nomi", userlar.RolesId);
            return View(userlar);
        }

        // POST: /Userlar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Login,Password,RolesId")] Userlar userlar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userlar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RolesId = new SelectList(db.Roles, "Id", "Nomi", userlar.RolesId);
            return View(userlar);
        }

        // GET: /Userlar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userlar userlar = db.Userlar.Find(id);
            if (userlar == null)
            {
                return HttpNotFound();
            }
            return View(userlar);
        }

        // POST: /Userlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Userlar userlar = db.Userlar.Find(id);
            db.Userlar.Remove(userlar);
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
