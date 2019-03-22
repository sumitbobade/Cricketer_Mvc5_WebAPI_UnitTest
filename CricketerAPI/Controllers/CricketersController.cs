using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DataModel;

namespace CricketerAPI.Controllers
{
    public class CricketersController : ApiController
    {
        private mvc5_CricketEntities db = new mvc5_CricketEntities();

        // GET: api/Cricketers
        public IQueryable<Cricketer> GetCricketers()
        {
            return db.Cricketers;
        }

        // GET: api/Cricketers/5
        [ResponseType(typeof(Cricketer))]
        public IHttpActionResult GetCricketer(int id)
        {
            Cricketer cricketer = db.Cricketers.Find(id);
            if (cricketer == null)
            {
                return NotFound();
            }

            return Ok(cricketer);
        }

        // PUT: api/Cricketers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCricketer(int id, Cricketer cricketer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cricketer.ID)
            {
                return BadRequest();
            }

            db.Entry(cricketer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CricketerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Cricketers
        [ResponseType(typeof(Cricketer))]
        public IHttpActionResult PostCricketer(Cricketer cricketer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cricketers.Add(cricketer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cricketer.ID }, cricketer);
        }

        // DELETE: api/Cricketers/5
        [ResponseType(typeof(Cricketer))]
        public IHttpActionResult DeleteCricketer(int id)
        {
            Cricketer cricketer = db.Cricketers.Find(id);
            if (cricketer == null)
            {
                return NotFound();
            }

            db.Cricketers.Remove(cricketer);
            db.SaveChanges();

            return Ok(cricketer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CricketerExists(int id)
        {
            return db.Cricketers.Count(e => e.ID == id) > 0;
        }
    }
}