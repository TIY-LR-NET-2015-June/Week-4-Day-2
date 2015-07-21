using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using W4D2HW.Models;

namespace W4D2HW.Controllers
{
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class ClassMatesController : Controller
    {
        public static List<Person> PersonList;

        public void GetClassMatesList()
        {

            PersonList = new List<Person>();
            PersonList.Add(new Person("Brandon", 35));
            PersonList.Add(new Person("Daniel", 34));
            PersonList.Add(new Person("Mike", 48));
            PersonList.Add(new Person("David", 18));
            PersonList.Add(new Person("Aaron", 21));
            PersonList.Add(new Person("Jason", 33));
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {

            PersonList = (List<Person>)requestContext.HttpContext.Session["Classmates"];
            if (PersonList == null)
            {
                GetClassMatesList();
                requestContext.HttpContext.Session["Classmates"] = PersonList;
            }
            return base.BeginExecute(requestContext, callback, state);
        }


        // GET: ClassMates
        public ActionResult Index()
        {
            return View(Session["Classmates"]);
        }

        // GET: ClassMates/Details/5
        public ActionResult Details(int id)
        {
            List<Person> tmp = (List<Person>)Session["Classmates"];

            return View(tmp.First(x => x.Id == id));
        }

        // GET: ClassMates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassMates/Create
        [HttpPost]
        public ActionResult Create(List<Person> peopleList)
        {
            try
            {
                foreach (Person p in peopleList)
                {
                    p.Id = PersonList.Count;
                    PersonList.Add(p);
                }

                Session["Classmates"] = PersonList;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ClassMates/Edit/5
        public ActionResult Edit(int id)
        {
            List<Person> tmp = (List<Person>)Session["Classmates"];
            return View(tmp.First(person => person.Id == id));
        }

        // POST: ClassMates/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Person p)
        {
            try
            {
                var tmp = (List<Person>)Session["Classmates"];
                var tmp2 = tmp.First(pe => pe.Id == id);
                tmp2.Name = p.Name;
                tmp2.YearsOld = p.YearsOld;
                Session["Classmates"] = tmp;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        // GET: ClassMates/Delete/5
        public ActionResult Delete(int id)
        {
            List<Person> oldList = (List<Person>)Session["Classmates"];

            return View(oldList.First(x => x.Id == id));
        }

        // POST: ClassMates/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Person p)
        {
            try
            {
                List<Person> oldList = (List<Person>)Session["Classmates"];
                oldList.RemoveAll(x => x.Id == id);
                Session["Classmates"] = oldList;
                PersonList = oldList;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
