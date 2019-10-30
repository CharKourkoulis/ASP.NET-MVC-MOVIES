using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThunderCats.Database;
using ThunderCats.Entities;
using ThunderCats.Entities.ViewModels;

namespace ThunderCats.Web.Controllers
{
    public class MovieController : Controller
    {
        private TsirkoContext db = new TsirkoContext();

        // GET: Movie
        public ActionResult Index()
        {
            var movies = db.Movies.Include(m => m.Category).Include(m => m.Director).Include(a => a.Actors);
            return View(movies.ToList());
        }


        // GET: Movie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }



        // GET: Movie/Create
        public ActionResult Create()
        {
            ViewBag.Genre = new SelectList(db.Categories, "Name", "Name");
            ViewBag.DirectorId = new SelectList(db.Directors, "Id", "Name");


            MovieViewModel vm = new MovieViewModel()
            {
                Movie = new Movie(),
                Actors = db.Actors.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name                  
                })
            };

            return View(vm);
        }


        // POST: Movie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Genre = new SelectList(db.Categories, "Name", "Name", vm.Movie.Genre);
                ViewBag.DirectorId = new SelectList(db.Directors, "Id", "Name", vm.Movie.DirectorId);
                return View(vm);
                //ViewBag.ActorId = new SelectList(db.Actors, "Id", "Name", vm.Movie.ActorId);

            }
            foreach (int id in vm.SelectedActors)
            {
                Actor actor = db.Actors.Find(id);
                if (actor != null)
                {
                    vm.Movie.Actors.Add(actor);
                }
            }

            db.Movies.Add(vm.Movie);
            db.SaveChanges();

            return RedirectToAction("Index");

            //Leipei kodikas paromoios me ton apo pano tis Get Create gia na provalw tous actors se periptosi pou den petixei to validation
        }


        // GET: Movie/Edit/5
        public ActionResult Edit(int? id)
        {

            Movie movie = db.Movies.Include("Category").Include("Director").Include("Actors")
                                   .Where(x => x.Id == id).FirstOrDefault();


            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.Genre = new SelectList(db.Categories, "Name", "Name", movie.Genre);
            ViewBag.DirectorId = new SelectList(db.Directors, "Id", "Name", movie.DirectorId);

            MovieViewModel vm = new MovieViewModel()
            {
                Movie = movie,
                Actors = db.Actors.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
            };


            return View(vm);
        }


        // POST: Movie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MovieViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Genre = new SelectList(db.Categories, "Name", "Name", vm.Movie.Genre);
                ViewBag.DirectorId = new SelectList(db.Directors, "Id", "Name", vm.Movie.DirectorId);
                return View(vm);
                //ViewBag.ActorId = new SelectList(db.Actors, "Id", "Name", vm.Movie.ActorId)
            }
            db.Movies.Attach(vm.Movie);
            db.Entry(vm.Movie).Collection("Actors").Load();
            vm.Movie.Actors.Clear();
            db.SaveChanges();
            foreach (int id in vm.SelectedActors)
            {
                Actor actor = db.Actors.Find(id);
                if (actor != null)
                {
                    vm.Movie.Actors.Add(actor);
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Movie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }


        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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
