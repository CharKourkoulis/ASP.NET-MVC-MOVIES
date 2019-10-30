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
    public class CategoryController : Controller
    {
        private IGenericRepository<Category> Repository { get; set; }


        public CategoryController()
        {
            Repository = new GenericRepository<Category>();
        }

        public CategoryController(IGenericRepository<Category> repository)
        {
            Repository = repository;
        }





            // GET: Category
            public ActionResult Index(string searchCategory)
        {
            var model = Repository.GetAll();
            return View(model);
        }



        // GET: Category/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category model = Repository.GetById(id);

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }


        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Age")] Category Category)
        {
            if (ModelState.IsValid)
            {
                Repository.Insert(Category);
                Repository.Save();

                return RedirectToAction("Index");
            }

            return View(Category);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category model = Repository.GetById(id);

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Age")] Category Category)
        {
            if (ModelState.IsValid)
            {
                Repository.Update(Category);
                return RedirectToAction("Index");
            }
            return View(Category);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category model = Repository.GetById(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Repository.Delete(id);
            Repository.Save();
            return RedirectToAction("Index");
        }

    }
}

