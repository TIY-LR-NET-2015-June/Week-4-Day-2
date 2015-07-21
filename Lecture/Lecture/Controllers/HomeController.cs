using Lecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lecture.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]

        public ActionResult Index()
        {
            Person p = new Person();
            p.Name = "Daniel";

            Session["Person"] = p;

            TempData["Message"] = "Some Message";

            ViewBag.SomeVariable = "Hello World";

            return View(p);
        }

        public ActionResult About()
        {
            Person someBody = (Person)Session["Person"];

            ViewBag.Message = someBody.Name;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}