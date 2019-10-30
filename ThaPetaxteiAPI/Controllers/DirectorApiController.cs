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

namespace ThaPetaxteiAPI.Controllers
{
    public class DirectorData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> MovieTitles { get; set; }

        public DirectorData()
        {
            MovieTitles = new List<string>();
        }
    }


    public class DirectorApiController : ApiController
    {
        private TsirkoContext db = new TsirkoContext();


        // GET: api/DirectorApi
        [Route(Name = "api/DirectorApi/SearchDirector")]
        public List<DirectorData> GetDirectors(string searchString = null)
        {
            var directors = new List<DirectorData>();


            if (!String.IsNullOrEmpty(searchString))
            {
               
               var filterdirectors = db.Directors.Where(d => d.Name.Contains(searchString)).Include(x => x.Movies);


                foreach (var director  in filterdirectors)
                {
                    var d = new DirectorData() { Id = director.Id, Age = director.Age, Name = director.Name };
                    foreach (var movie in director.Movies)
                    {
                        d.MovieTitles.Add(movie.Title);
                    }
                    directors.Add(d);
                }
                return directors.ToList();
            }


            foreach (var director in db.Directors.Include(x => x.Movies))
            {
                var d = new DirectorData() { Id = director.Id, Age = director.Age, Name = director.Name };
                foreach (var movie in director.Movies)
                {
                    d.MovieTitles.Add(movie.Title);
                }
                directors.Add(d);
            }
            return directors.ToList();
        }

      
    // GET: api/DirectorApi/5
    [ResponseType(typeof(Director))]
        public IHttpActionResult GetDirector(int id)
        {
            Director director = db.Directors.Find(id);
            if (director == null)
            {
                return NotFound();
            }

            return Ok(director);
        }

        // PUT: api/DirectorApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDirector(int id, Director director)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != director.Id)
            {
                return BadRequest();
            }

            db.Entry(director).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectorExists(id))
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

        // POST: api/DirectorApi
        [ResponseType(typeof(Director))]
        public IHttpActionResult PostDirector(Director director)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Directors.Add(director);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = director.Id }, director);
        }

        // DELETE: api/DirectorApi/5
        [ResponseType(typeof(Director))]
        public IHttpActionResult DeleteDirector(int id)
        {
            Director director = db.Directors.Find(id);
            if (director == null)
            {
                return NotFound();
            }

            db.Directors.Remove(director);
            db.SaveChanges();

            return Ok(director);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DirectorExists(int id)
        {
            return db.Directors.Count(e => e.Id == id) > 0;
        }
    }
}