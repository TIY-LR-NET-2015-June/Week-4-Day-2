using homework_week4day2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace homework_week4day2.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person

       

        public ActionResult Create()
        {
            return View();
        }
        // Post: Person/Create
        [HttpPost]
        public ActionResult Create (Person person)
        {

            people.Add(person);
            Session["Person"] = people;

                // Todo: add insert logoc here
            return RedirectToAction("Index");
            
        }
        public ActionResult Index()
        {
            return View(people);
        }
        List<Person> people = new List<Person>();
        
    }

}
