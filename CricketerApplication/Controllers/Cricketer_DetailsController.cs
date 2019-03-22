﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataModel;

namespace CricketerApplication.Controllers
{
    public class Cricketer_DetailsController : Controller
    {
        private mvc5_CricketEntities db = new mvc5_CricketEntities();

        // GET: Cricketer_Details
        public ActionResult Index()
        {
            var cricketer_Details = db.Cricketer_Details.Include(c => c.Cricketer);
            return View(cricketer_Details.ToList());
        }

        // GET: Cricketer_Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cricketer_Details cricketer_Details = db.Cricketer_Details.Find(id);
            if (cricketer_Details == null)
            {
                return HttpNotFound();
            }
            return View(cricketer_Details);
        }

        // GET: Cricketer_Details/Create
        public ActionResult Create()
        {
            ViewBag.Cricketer_ID = new SelectList(db.Cricketers, "ID", "Name");
            return View();
        }

        // POST: Cricketer_Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Details_ID,Cricketer_ID,Team,ODI_Runs,Test_Runs,Wickets")] Cricketer_Details cricketer_Details)
        {
            if (ModelState.IsValid)
            {
                db.Cricketer_Details.Add(cricketer_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cricketer_ID = new SelectList(db.Cricketers, "ID", "Name", cricketer_Details.Cricketer_ID);
            return View(cricketer_Details);
        }

        // GET: Cricketer_Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cricketer_Details cricketer_Details = db.Cricketer_Details.Find(id);
            if (cricketer_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cricketer_ID = new SelectList(db.Cricketers, "ID", "Name", cricketer_Details.Cricketer_ID);
            return View(cricketer_Details);
        }

        // POST: Cricketer_Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Details_ID,Cricketer_ID,Team,ODI_Runs,Test_Runs,Wickets")] Cricketer_Details cricketer_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cricketer_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cricketer_ID = new SelectList(db.Cricketers, "ID", "Name", cricketer_Details.Cricketer_ID);
            return View(cricketer_Details);
        }

        // GET: Cricketer_Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cricketer_Details cricketer_Details = db.Cricketer_Details.Find(id);
            if (cricketer_Details == null)
            {
                return HttpNotFound();
            }
            return View(cricketer_Details);
        }

        // POST: Cricketer_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cricketer_Details cricketer_Details = db.Cricketer_Details.Find(id);
            db.Cricketer_Details.Remove(cricketer_Details);
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
