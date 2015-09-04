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
using PacmanREST.Models;

namespace PacmanREST.Controllers
{
    public class LocationController : ApiController
    {
        private pacmanAndroidNew_dbEntities db = new pacmanAndroidNew_dbEntities();

        // GET: api/Location
        public IQueryable<Pacman_location_db> GetPacman_location_db()
        {
            return db.Pacman_location_db;
        }

        // GET: api/Location/5
        [ResponseType(typeof(Pacman_location_db))]
        public IHttpActionResult GetPacman_location_db(int id)
        {
            Pacman_location_db pacman_location_db = db.Pacman_location_db.Find(id);
            if (pacman_location_db == null)
            {
                return NotFound();
            }

            return Ok(pacman_location_db);
        }

        // PUT: api/Location/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPacman_location_db(int id, Pacman_location_db pacman_location_db)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pacman_location_db.ID)
            {
                return BadRequest();
            }

            db.Entry(pacman_location_db).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Pacman_location_dbExists(id))
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

        // POST: api/Location
        [ResponseType(typeof(Pacman_location_db))]
        public IHttpActionResult PostPacman_location_db(Pacman_location_db pacman_location_db)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pacman_location_db.Add(pacman_location_db);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pacman_location_db.ID }, pacman_location_db);
        }

        // DELETE: api/Location/5
        [ResponseType(typeof(Pacman_location_db))]
        public IHttpActionResult DeletePacman_location_db(int id)
        {
            Pacman_location_db pacman_location_db = db.Pacman_location_db.Find(id);
            if (pacman_location_db == null)
            {
                return NotFound();
            }

            db.Pacman_location_db.Remove(pacman_location_db);
            db.SaveChanges();

            return Ok(pacman_location_db);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Pacman_location_dbExists(int id)
        {
            return db.Pacman_location_db.Count(e => e.ID == id) > 0;
        }
    }
}