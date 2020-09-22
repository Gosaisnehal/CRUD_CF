using CRUD_CF.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CRUD_CF.Controllers
{
    public class CountryController : Controller
    {
        private crudDBContext db = new crudDBContext();

        // GET: Lists all country
        public ActionResult Index()
        {
            var data = db.Countries.ToList();
            return View(data);
        }

        // GET: Create Country
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "countryId,countryName,setDefault")] Country country)
        {
            if (ModelState.IsValid)
            {

               if(country.setDefault)
                { foreach(Country countries in db.Countries)
                    {
                        countries.setDefault = false;
                    }       
                }
                db.Countries.Add(country);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(country);
        }


        // GET: Create/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country contact = db.Countries.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            //var CountryListSP = db.Countries.ToList();
            //ViewBag.CountryList = new SelectList(CountryListSP, "countryId", "countryName");
            return View(contact);
        }

        // POST: Create/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "countryId,countryName,setDefault")] Country country)
            {
            db.Entry(country).State = EntityState.Modified;
            if (ModelState.IsValid)
            {
                if (country.setDefault)
                {
                    foreach (Country countries in db.Countries)
                    {
                        countries.setDefault = false;
                    }
                    country.setDefault = true;
                    
                }
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(country);
        }

        // GET: Create/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // GET: Create/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        [HttpPost]
        public ActionResult Delete(int id, Country model)
        {
            using (var db = new crudDBContext())
            {
                // accessing pertcular record for matching ID,choosen from  
                var data = db.Countries.Where(x => x.countryId == id).SingleOrDefault();

                if (data != null)
                { 
                    if(data.setDefault)
                    {

                        var item = db.Countries.Where(x => x.countryId == 1).SingleOrDefault();
                        item.setDefault = true;
                        //db.Countries.SqlQuery("Set setDefault= 1 Where dbo.Countries.countryId =4");
                    }
                    db.Countries.Remove(data);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();

                }
            }

        }

       [HttpGet]
       public ActionResult Default()
        {          
            var list = db.Countries.ToList();
            ViewBag.CountryList = new SelectList(list, "countryId", "countryName" );
            return View();
        }

        [HttpPost]
        public ActionResult Default([Bind(Include = "countryId,countryName,setDefault")] Country country)
        {
                                       
        //        db.Entry(country).State = EntityState.Modified;
        //        db.SaveChanges();
        //      return RedirectToAction("Index");            
         return View(country);
         }

    }
}