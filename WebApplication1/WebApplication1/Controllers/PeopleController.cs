using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Web.Mvc.Html;

namespace WebApplication1.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People
        public ActionResult Index()
        {
            return View(Session["ClassMates"]);
        }

        // GET: People/Details/5
        public ActionResult Details(int id)
        {
            List<Persons> peoples = (List<Persons>)Session["ClassMates"];

            var person = peoples.First();
            return View(person);
        }
        // GET: People/Create]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        [HttpPost]
        public ActionResult Create(List<Persons> people)
        {
            try
            {
                List<Persons> oldPeople = new List<Persons>();
                if (Session["ClassMates"] != null)
                    oldPeople = (List<Persons>)Session["ClassMates"];

                oldPeople.AddRange(people);
                Session["ClassMates"] = oldPeople;

                return RedirectToAction("Index");
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        // GET: People/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: People/Edit/5
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
                return RedirectToAction("Index");
            }
        }

        // GET: People/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: People/Delete/5
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
