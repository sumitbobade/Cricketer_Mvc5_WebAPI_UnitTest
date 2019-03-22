using System;
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
    public class Cricketer_ODI_StatisticsController : Controller
    {
        private mvc5_CricketEntities db = new mvc5_CricketEntities();

        // GET: Cricketer_ODI_Statistics
        public ActionResult Index()
        {
            var cricketer_ODI_Statistics = db.Cricketer_ODI_Statistics.Include(c => c.Cricketer);
            return View(cricketer_ODI_Statistics.ToList());
        }

        // GET: Cricketer_ODI_Statistics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cricketer_ODI_Statistics cricketer_ODI_Statistics = db.Cricketer_ODI_Statistics.Find(id);
            if (cricketer_ODI_Statistics == null)
            {
                return HttpNotFound();
            }
            return View(cricketer_ODI_Statistics);
        }

        // GET: Cricketer_ODI_Statistics/Create
        public ActionResult Create()
        {
            ViewBag.Cricketer_ID = new SelectList(db.Cricketers, "ID", "Name");
            return View();
        }

        // POST: Cricketer_ODI_Statistics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ODI_ID,Cricketer_ID,Name,Half_Century,Century")] Cricketer_ODI_Statistics cricketer_ODI_Statistics)
        {
            if (ModelState.IsValid)
            {
                db.Cricketer_ODI_Statistics.Add(cricketer_ODI_Statistics);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cricketer_ID = new SelectList(db.Cricketers, "ID", "Name", cricketer_ODI_Statistics.Cricketer_ID);
            return View(cricketer_ODI_Statistics);
        }

        // GET: Cricketer_ODI_Statistics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cricketer_ODI_Statistics cricketer_ODI_Statistics = db.Cricketer_ODI_Statistics.Find(id);
            if (cricketer_ODI_Statistics == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cricketer_ID = new SelectList(db.Cricketers, "ID", "Name", cricketer_ODI_Statistics.Cricketer_ID);
            return View(cricketer_ODI_Statistics);
        }

        // POST: Cricketer_ODI_Statistics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ODI_ID,Cricketer_ID,Name,Half_Century,Century")] Cricketer_ODI_Statistics cricketer_ODI_Statistics)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cricketer_ODI_Statistics).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cricketer_ID = new SelectList(db.Cricketers, "ID", "Name", cricketer_ODI_Statistics.Cricketer_ID);
            return View(cricketer_ODI_Statistics);
        }

        // GET: Cricketer_ODI_Statistics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cricketer_ODI_Statistics cricketer_ODI_Statistics = db.Cricketer_ODI_Statistics.Find(id);
            if (cricketer_ODI_Statistics == null)
            {
                return HttpNotFound();
            }
            return View(cricketer_ODI_Statistics);
        }

        // POST: Cricketer_ODI_Statistics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cricketer_ODI_Statistics cricketer_ODI_Statistics = db.Cricketer_ODI_Statistics.Find(id);
            db.Cricketer_ODI_Statistics.Remove(cricketer_ODI_Statistics);
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
