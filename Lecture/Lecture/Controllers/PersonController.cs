using Lecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Routing;

namespace Lecture.Controllers
{
    
    public class PersonController : Controller
    {
       
        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.Session["Peoples"] == null)
            {
                List<Person> peoples = new List<Person>();
                peoples.Add(new Person() { Id = 1, Name = "Daniel" });
                peoples.Add(new Person() { Id = 2, Name = "Scott" });
                peoples.Add(new Person() { Id = 3, Name = "Brandon" });
                requestContext.HttpContext.Session["Peoples"] = peoples;
            }

            return base.BeginExecute(requestContext, callback, state);
        }

        public ActionResult AuthorizeMe()
        { 
            FormsAuthentication.SetAuthCookie("danielrules",false);

            return RedirectToAction("Details", new { Id = 1 });
        }
        // GET: Person
        public ActionResult Index()
        {



            return View(Session["Peoples"]);

            
        }

        // GET: Person/Details/5
        
        public ActionResult Details(int id)
        {
            List<Person> peoples = (List<Person>)Session["Peoples"];

            var person = peoples.First(x => x.Id == id);
            return View(person);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IEnumerable<Person> peoples)
        {
            try
            {
                // TODO: Add insert logic here
                List<Person> oldPeople = (List<Person>)Session["Peoples"];
                oldPeople.AddRange(peoples);
                Session["Peoples"] = oldPeople;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
