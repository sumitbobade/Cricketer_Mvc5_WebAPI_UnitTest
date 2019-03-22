using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
//using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using DataModel;

namespace CricketerApplication.Controllers
{
    public class CricketersController : Controller
    {
        private mvc5_CricketEntities db = new mvc5_CricketEntities();

        // GET: Cricketers
        public ActionResult Index(string search ,string GradeList)
        {
            //var CricketerList = db.Cricketers.ToList();

            //var DBGradeList = new List<string>();
            //var AllGrade = db.Cricketers.Select(c=>c.Grade);
            //DBGradeList.AddRange(AllGrade.Distinct());

            //ViewBag.GradeList = new SelectList(DBGradeList);

            //if (!string.IsNullOrEmpty(search))
            //{
            //    CricketerList = CricketerList.Where(c => c.Name.Contains(search)).ToList();
            //}

            //if (!string.IsNullOrEmpty(GradeList))
            //{
            //    CricketerList = CricketerList.Where(c => c.Grade.Equals(GradeList)).ToList();
            //}


            //return View(CricketerList);





            //API call/$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

            IList<Cricketer> cricList = new List<Cricketer>();

            var DBGradeList = new List<string>();
            var AllGrade = db.Cricketers.Select(c => c.Grade);
            DBGradeList.AddRange(AllGrade.Distinct());

            ViewBag.GradeList = new SelectList(DBGradeList);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:46853/api/Cricketers");

                var responce = client.GetAsync(client.BaseAddress);
                responce.Wait();

                var result = responce.Result;

                if (result.IsSuccessStatusCode)
                {
                    var read = result.Content.ReadAsAsync<IList<Cricketer>>();
                    read.Wait();

                    cricList = read.Result;
                    if (!string.IsNullOrEmpty(search))
                    {
                        cricList = cricList.Where(c => c.Name.Contains(search)).ToList();
                    }

                    if (!string.IsNullOrEmpty(GradeList))
                    {
                        cricList = cricList.Where(c => c.Grade.Equals(GradeList)).ToList();
                    }
                }
                else
                {
                    cricList = null;

                    ModelState.AddModelError(string.Empty, "Server Error, Please contact Sumit");
                }

            }

            return View(cricList);


            //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$


            //###### Ajax ##############################################

            //return View("Index_AjaxAPI");
        }

        // GET: Cricketers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cricketer cricketer = db.Cricketers.Find(id);
            if (cricketer == null)
            {
                return HttpNotFound();
            }
            return View(cricketer);
        }

        // GET: Cricketers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cricketers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,ODI,Test,Grade")] Cricketer cricketer)
        {
            if (ModelState.IsValid)
            {
                db.Cricketers.Add(cricketer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cricketer);
        }

        // GET: Cricketers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cricketer cricketer = db.Cricketers.Find(id);
            if (cricketer == null)
            {
                return HttpNotFound();
            }
            return View(cricketer);
        }

        // POST: Cricketers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,ODI,Test,Grade")] Cricketer cricketer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cricketer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cricketer);
        }

        // GET: Cricketers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cricketer cricketer = db.Cricketers.Find(id);
            if (cricketer == null)
            {
                return HttpNotFound();
            }
            return View(cricketer);
        }

        // POST: Cricketers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cricketer cricketer = db.Cricketers.Find(id);
            db.Cricketers.Remove(cricketer);
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
