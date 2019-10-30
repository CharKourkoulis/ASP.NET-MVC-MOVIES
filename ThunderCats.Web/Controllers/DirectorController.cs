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
    public class DirectorController : Controller
    {
        private IGenericRepository<Director> Repository { get; set; }


        public DirectorController()
        {
            Repository = new GenericRepository<Director>();
        }

        public DirectorController(IGenericRepository<Director> repository)
        {
            Repository = repository;
        }





        // GET: Actor
        public ActionResult Index(string searchDirector)
        {
            var model = Repository.GetAll();
            return View(model);
        }



        // GET: Director/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Director model = Repository.GetById(id);

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }


        // GET: Director/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Director/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Age")] Director Director)
        {
            if (ModelState.IsValid)
            {
                Repository.Insert(Director);
                Repository.Save();

                return RedirectToAction("Index");
            }

            return View(Director);
        }

        // GET: Director/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Director model = Repository.GetById(id);

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Director/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Age")] Director Director)
        {
            if (ModelState.IsValid)
            {
                Repository.Update(Director);
                return RedirectToAction("Index");
            }
            return View(Director);
        }

        // GET: Director/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Director model = Repository.GetById(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Director/Delete/5
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
