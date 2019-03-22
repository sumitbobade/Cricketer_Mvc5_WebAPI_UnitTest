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
    public class Cricketer_Test_StatisticsController : Controller
    {
        private mvc5_CricketEntities db = new mvc5_CricketEntities();

        // GET: Cricketer_Test_Statistics
        public ActionResult Index()
        {
            var cricketer_Test_Statistics = db.Cricketer_Test_Statistics.Include(c => c.Cricketer);
            return View(cricketer_Test_Statistics.ToList());
        }

        // GET: Cricketer_Test_Statistics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cricketer_Test_Statistics cricketer_Test_Statistics = db.Cricketer_Test_Statistics.Find(id);
            if (cricketer_Test_Statistics == null)
            {
                return HttpNotFound();
            }
            return View(cricketer_Test_Statistics);
        }

        // GET: Cricketer_Test_Statistics/Create
        public ActionResult Create()
        {
            ViewBag.Cricketer_ID = new SelectList(db.Cricketers, "ID", "Name");
            return View();
        }

        // POST: Cricketer_Test_Statistics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Test_ID,Cricketer_ID,Name,Half_Century,Century")] Cricketer_Test_Statistics cricketer_Test_Statistics)
        {
            if (ModelState.IsValid)
            {
                db.Cricketer_Test_Statistics.Add(cricketer_Test_Statistics);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cricketer_ID = new SelectList(db.Cricketers, "ID", "Name", cricketer_Test_Statistics.Cricketer_ID);
            return View(cricketer_Test_Statistics);
        }

        // GET: Cricketer_Test_Statistics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cricketer_Test_Statistics cricketer_Test_Statistics = db.Cricketer_Test_Statistics.Find(id);
            if (cricketer_Test_Statistics == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cricketer_ID = new SelectList(db.Cricketers, "ID", "Name", cricketer_Test_Statistics.Cricketer_ID);
            return View(cricketer_Test_Statistics);
        }

        // POST: Cricketer_Test_Statistics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Test_ID,Cricketer_ID,Name,Half_Century,Century")] Cricketer_Test_Statistics cricketer_Test_Statistics)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cricketer_Test_Statistics).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cricketer_ID = new SelectList(db.Cricketers, "ID", "Name", cricketer_Test_Statistics.Cricketer_ID);
            return View(cricketer_Test_Statistics);
        }

        // GET: Cricketer_Test_Statistics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cricketer_Test_Statistics cricketer_Test_Statistics = db.Cricketer_Test_Statistics.Find(id);
            if (cricketer_Test_Statistics == null)
            {
                return HttpNotFound();
            }
            return View(cricketer_Test_Statistics);
        }

        // POST: Cricketer_Test_Statistics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cricketer_Test_Statistics cricketer_Test_Statistics = db.Cricketer_Test_Statistics.Find(id);
            db.Cricketer_Test_Statistics.Remove(cricketer_Test_Statistics);
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
