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
    public class PatientsController : Controller
    {
        private BloodBankEntities db = new BloodBankEntities();

        // GET: Patients
        public ActionResult Index(string searchBy,string search)
        {
            var patients = db.Patients.Include(p => p.BloodStock).Include(p => p.Gender);
            if (searchBy == "Address")
            {
                return View(db.Patients.Where(x => x.Address.StartsWith(search) || search == null).ToList());
            }
            else
            {
                return View(db.Patients.Where(x => x.PatientName.StartsWith(search) || search == null).ToList());
            }
        }

        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            ViewBag.BloodListId = new SelectList(db.BloodStocks, "BloodListId", "BloodName");
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "Gender1");
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientID,PatientName,GenderId,Birth_Date,ContactNo,Email,Address,BloodListId")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BloodListId = new SelectList(db.BloodStocks, "BloodListId", "BloodName", patient.BloodListId);
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "Gender1", patient.GenderId);
            return View(patient);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            ViewBag.BloodListId = new SelectList(db.BloodStocks, "BloodListId", "BloodName", patient.BloodListId);
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "Gender1", patient.GenderId);
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientID,PatientName,GenderId,Birth_Date,ContactNo,Email,Address,BloodListId")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BloodListId = new SelectList(db.BloodStocks, "BloodListId", "BloodName", patient.BloodListId);
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "Gender1", patient.GenderId);
            return View(patient);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
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
