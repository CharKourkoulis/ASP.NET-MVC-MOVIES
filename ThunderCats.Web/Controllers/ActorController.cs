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
using ThunderCats.Services;
using ThunderCats.Services.GenericServices;

namespace ThunderCats.Web.Controllers
{
    public class ActorController : Controller
    {
       private IGenericRepository<Actor> Repository { get; set; }

        public ActorController()
        {
            Repository = new GenericRepository<Actor>();
        }

        public ActorController(IGenericRepository<Actor> repository)
        {
            Repository = repository;
        }

        // GET: Actor
        public ActionResult Index(string searchActor)
        {

            var model = Repository.GetAll();
            return View(model);
        }



        // GET: Actor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             Actor model = Repository.GetById(id);
           
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }


        // GET: Actor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Actor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Age")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                Repository.Insert(actor);
                Repository.Save();
                
                return RedirectToAction("Index");
            }

            return View(actor);
        }

        // GET: Actor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Actor model = Repository.GetById(id);

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Actor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Age")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                Repository.Update(actor);
                return RedirectToAction("Index");
            }
            return View(actor);
        }

        // GET: Actor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           Actor model = Repository.GetById(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Actor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Repository.Delete(id);
            Repository.Save();
            return RedirectToAction("Index");
        }

    }
}
