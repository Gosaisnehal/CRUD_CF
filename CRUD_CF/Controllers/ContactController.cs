using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUD_CF;
using CRUD_CF.DAL;
using CRUD_CF.Migrations;
using CRUD_CF.Models;
using System.Collections;

namespace CRUD_CF.Controllers
{
    public class ContactController : Controller
    {
        private crudDBContext db = new crudDBContext();

        // GET: Create
        public ActionResult Index()
        {
            
            var data = db.Contacts.ToList();
            var CountryListSP = db.Countries.ToList();
            //var defaultCountry = ; 
            ViewBag.CountryList = new SelectList(CountryListSP, "countryId", "countryName" );
            return View(data);
        }

        // GET: Create/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: Create/Create
        public ActionResult Create()
        {
            crudDBContext db = new crudDBContext();

            // 1st method , displays default country first and with the others listed also
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (Country country in db.Countries)
            {
                SelectListItem selectListItem = new SelectListItem
                {
                    Text = country.countryName,
                    Value = country.countryId.ToString(),
                    Selected = country.setDefault.Equals(true)
                };
                selectListItems.Add(selectListItem);
            }
            ViewBag.countryId = selectListItems;

            // 2nd method , displays only the one selected as default
            //var CountryListSP = db.Countries.ToList().Where(model => model.setDefault == true); 
            //ViewBag.countryId = new SelectList(CountryListSP, "countryId", "countryName");

            //3rd method , displays all countries in the list 
            //var CountryListSP = db.Countries.ToList();
            //ViewBag.countryId = new SelectList(CountryListSP, "countryId", "countryName");

            return View();
        }

        // POST: Create/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,firstName,lastName,e_mail,phoneNo,unitNo,streetNo,streetName,suburb,state,company,countryId,isActionSelected")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: Create/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            var CountryListSP = db.Countries.ToList();
            ViewBag.CountryList = new SelectList(CountryListSP, "countryId", "countryName");
            return View(contact);
        }

        // POST: Create/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,firstName,lastName,e_mail,phoneNo,unitNo,streetNo,streetName,suburb,state,company,countryId,isActionSelected")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Create/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        [HttpPost]
        public ActionResult Delete(int id, Contact model)
        {
            using (var db = new crudDBContext())
            {
                // accessing pertcular record for matching ID,choosen from  
                var data = db.Contacts.Where(x => x.ID == id).SingleOrDefault();

                if (data != null)
                {
                    db.Contacts.Remove(data);
                    db.SaveChanges();
                    return RedirectToAction("Read");
                }
                else
                {
                    return View();

                }
            }

        }
        //// POST: Create/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Contact contact = db.Contacts.Find(id);
        //    db.Contacts.Remove(contact);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
