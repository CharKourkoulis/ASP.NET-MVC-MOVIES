using Imerologio.Managers;
using Imerologio.Models;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Imerologio.EmployeeManagerFactory;


namespace Imerologio.Controllers
{
    public class BasicController : Controller
    {

        private ILog _ilog;


        public BasicController()
        {
            _ilog = Log.GetInstance;
        }

        // GET: Basic
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Age")] Employee employee)
        {

            EmployeeManagerFactoryMethod employeeTypeFactory = new EmployeeManagerFactoryMethod();

            var emp = employeeTypeFactory.GetEmployeeManager();

            if (ModelState.IsValid)
            {

                Repository.Insert(employee);
                Repository.Save();

                return RedirectToAction("Index");
            }

            return View(employee);
        }




    }
}