using PhoneBookMVCApp.Context;
using PhoneBookMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBookMVCApp.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People
        PeopleContext db = new PeopleContext();

        public ActionResult Index(string p)
        {

            var values = from d in db.Peoples select d;
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(x => x.perName.Contains(p) || x.perSurname.Contains(p) );
            }

            return View(values.ToList());
        }
        [HttpGet]

        public ActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPerson(People p1)
        {

            if (ModelState.IsValid)
            {
                db.Peoples.Add(p1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p1);
        }
        public ActionResult ManagePeople()
        {
            return View(db.Peoples.ToList());
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            People ppl = db.Peoples.Find(id);
            db.Peoples.Remove(ppl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            People kayit = db.Peoples.FirstOrDefault(k => k.id == id);
            return View(kayit);
        }
        [HttpPost]

        public ActionResult Edit(People ppl)
        {
            People people = db.Peoples.Where(x => x.id == ppl.id).FirstOrDefault();
            people.id = ppl.id;
            people.perName = ppl.perName;
            people.perSurname = ppl.perSurname;
            people.email = ppl.email;
            people.perPhone = ppl.perPhone;

            db.SaveChanges();
            ViewBag.sonuc = "Person Updated";
            return View();
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            People kayit = db.Peoples.FirstOrDefault(k => k.id == id);
            return View(kayit);
        }
        public ActionResult Contact()
        {
            return View();
        }
        //public ActionResult Search(int id)
        //{

        //    People src= db.Peoples.FirstOrDefault(k => k.id == id);
        //    return View(src);

        //    //List<People> peoples = db.Peoples.ToList();
        //    //return View(peoples); 
        //}
    }
}