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
using ThunderCats.Database;
using ThunderCats.Entities;

namespace ThunderCats.Web.Controllers
{
    public class ActorApiController : ApiController
    {
        private TsirkoContext db = new TsirkoContext();

        // GET: api/ActorApi
        public IQueryable<Actor> GetActors()
        {
            return db.Actors;
        }

        // GET: api/ActorApi/5
        [ResponseType(typeof(Actor))]
        public IHttpActionResult GetActor(int id)
        {
            Actor actor = db.Actors.Find(id);
            if (actor == null)
            {
                return NotFound();
            }

            return Ok(actor);
        }

        // PUT: api/ActorApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutActor(int id, Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != actor.Id)
            {
                return BadRequest();
            }

            db.Entry(actor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActorExists(id))
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

        // POST: api/ActorApi
        [ResponseType(typeof(Actor))]
        public IHttpActionResult PostActor(Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Actors.Add(actor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = actor.Id }, actor);
        }

        // DELETE: api/ActorApi/5
        [ResponseType(typeof(Actor))]
        public IHttpActionResult DeleteActor(int id)
        {
            Actor actor = db.Actors.Find(id);
            if (actor == null)
            {
                return NotFound();
            }

            db.Actors.Remove(actor);
            db.SaveChanges();

            return Ok(actor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActorExists(int id)
        {
            return db.Actors.Count(e => e.Id == id) > 0;
        }
    }
}