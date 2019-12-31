using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BloodBankManagementSystem;

namespace BloodBankManagementSystem.Controllers
{
    public class DonorsController : Controller
    {
        private BloodBankEntities db = new BloodBankEntities();

        // GET: Donors
        public ActionResult Index(string searchBy, string search)
        {
            var donors = db.Donors.Include(d => d.Gender).Include(d => d.BloodStock);

            if (searchBy == "Address")
            {
                return View(db.Donors.Where(x => x.Address.StartsWith(search) || search == null).ToList());
            }
            else
            {
                return View(db.Donors.Where(x => x.DonorName.StartsWith(search) || search == null).ToList());
            }
        }

        // GET: Donors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donor donor = db.Donors.Find(id);
            if (donor == null)
            {
                return HttpNotFound();
            }
            return View(donor);
        }

        // GET: Donors/Create
        public ActionResult Create()
        {
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "Gender1");
            ViewBag.BloodListId = new SelectList(db.BloodStocks, "BloodListId", "BloodName");
            return View();
        }

        // POST: Donors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DonorId,DonorName,GenderId,Birth_Date,ContactNo,Email,Donation_Date,Address,BloodListId")] Donor donor)
        {
            if (ModelState.IsValid)
            {
                db.Donors.Add(donor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "Gender1", donor.GenderId);
            ViewBag.BloodListId = new SelectList(db.BloodStocks, "BloodListId", "BloodName", donor.BloodListId);
            return View(donor);
        }

        // GET: Donors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donor donor = db.Donors.Find(id);
            if (donor == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "Gender1", donor.GenderId);
            ViewBag.BloodListId = new SelectList(db.BloodStocks, "BloodListId", "BloodName", donor.BloodListId);
            return View(donor);
        }

        // POST: Donors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DonorId,DonorName,GenderId,Birth_Date,ContactNo,Email,Donation_Date,Address,BloodListId")] Donor donor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "Gender1", donor.GenderId);
            ViewBag.BloodListId = new SelectList(db.BloodStocks, "BloodListId", "BloodName", donor.BloodListId);
            return View(donor);
        }

        // GET: Donors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donor donor = db.Donors.Find(id);
            if (donor == null)
            {
                return HttpNotFound();
            }
            return View(donor);
        }

        // POST: Donors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donor donor = db.Donors.Find(id);
            db.Donors.Remove(donor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
