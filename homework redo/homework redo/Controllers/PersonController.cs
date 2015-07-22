using homework_redo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace homework_redo.Controllers
{

    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
           
            return View(Session["Person"]);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Person/Create
       
        public ActionResult Create()
        {

          
            return View();
        }
        public List<Person> Roster = new List<Person>();

        // POST: Person/Create
        [HttpPost]

        public ActionResult Create(FormCollection collection)

        {


            // TODO: Add insert logic here
            for (int i = 1; i<10; i+=2)
                    {
                    Person p = new Person();
                    p.Age = Convert.ToInt32(collection[i]);
                    p.Name = collection[i + 1];
                    Roster.Add(p);
                    }
                Session["Person"] = Roster;
                return RedirectToAction("Index");
            
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
