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
    public class BloodDetailsController : Controller
    {
        private BloodBankEntities db = new BloodBankEntities();

        // GET: BloodDetails
        public ActionResult Index()
        {
            return View(db.BloodDetails.ToList());
        }

        // GET: BloodDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodDetail bloodDetail = db.BloodDetails.Find(id);
            if (bloodDetail == null)
            {
                return HttpNotFound();
            }
            return View(bloodDetail);
        }

        // GET: BloodDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BloodDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BloodId,BloodName,BloodDescription")] BloodDetail bloodDetail)
        {
            if (ModelState.IsValid)
            {
                db.BloodDetails.Add(bloodDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bloodDetail);
        }

        // GET: BloodDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodDetail bloodDetail = db.BloodDetails.Find(id);
            if (bloodDetail == null)
            {
                return HttpNotFound();
            }
            return View(bloodDetail);
        }

        // POST: BloodDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BloodId,BloodName,BloodDescription")] BloodDetail bloodDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloodDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bloodDetail);
        }

        // GET: BloodDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodDetail bloodDetail = db.BloodDetails.Find(id);
            if (bloodDetail == null)
            {
                return HttpNotFound();
            }
            return View(bloodDetail);
        }

        // POST: BloodDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BloodDetail bloodDetail = db.BloodDetails.Find(id);
            db.BloodDetails.Remove(bloodDetail);
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
