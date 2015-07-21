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
        List<Person> people = new List<Person>();
        // GET: Person
        public ActionResult Index()
        {
            return View(people);
        }
        public ActionResult Create()
        {
            return View();
        }
        // Post: Person/Create
        [HttpPost]
        public ActionResult Create (Person person)
        {
           
            people.Add(person);
            
                // Todo: add insert logoc here
                return RedirectToAction("Index");
            
        }
    }

}
