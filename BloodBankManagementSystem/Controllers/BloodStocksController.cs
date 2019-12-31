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
    public class BloodStocksController : Controller
    {
        private BloodBankEntities db = new BloodBankEntities();

        // GET: BloodStocks
        public ActionResult Index()
        {
            return View(db.BloodStocks.ToList());
        }

        // GET: BloodStocks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodStock bloodStock = db.BloodStocks.Find(id);
            if (bloodStock == null)
            {
                return HttpNotFound();
            }
            return View(bloodStock);
        }

        // GET: BloodStocks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BloodStocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BloodListId,BloodName")] BloodStock bloodStock)
        {
            if (ModelState.IsValid)
            {
                db.BloodStocks.Add(bloodStock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bloodStock);
        }

        // GET: BloodStocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodStock bloodStock = db.BloodStocks.Find(id);
            if (bloodStock == null)
            {
                return HttpNotFound();
            }
            return View(bloodStock);
        }

        // POST: BloodStocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BloodListId,BloodName")] BloodStock bloodStock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloodStock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bloodStock);
        }

        // GET: BloodStocks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodStock bloodStock = db.BloodStocks.Find(id);
            if (bloodStock == null)
            {
                return HttpNotFound();
            }
            return View(bloodStock);
        }

        // POST: BloodStocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           // using (var conte)
            BloodStock bloodStock = db.BloodStocks.Find(id);
            db.BloodStocks.Remove(bloodStock);
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
