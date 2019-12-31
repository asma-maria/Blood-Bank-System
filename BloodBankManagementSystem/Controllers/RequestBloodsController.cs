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
    public class RequestBloodsController : Controller
    {
        private BloodBankEntities db = new BloodBankEntities();

        // GET: RequestBloods
        public ActionResult Index(string searchBy,string search)
        {
            var requestBloods = db.RequestBloods.Include(r => r.BloodDetail).Include(r => r.BloodStock);
            if (searchBy == "Gender")
            {
                return View(db.RequestBloods.Where(x => x.Gender.StartsWith(search) || search == null).ToList());
            }
            else
            {
                return View(db.RequestBloods.Where(x => x.Name.StartsWith(search) || search == null).ToList());
            }
         
        }

        // GET: RequestBloods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestBlood requestBlood = db.RequestBloods.Find(id);
            if (requestBlood == null)
            {
                return HttpNotFound();
            }
            return View(requestBlood);
        }

        // GET: RequestBloods/Create
        public ActionResult Create()
        {
            ViewBag.BloodId = new SelectList(db.BloodDetails, "BloodId", "BloodDescription");
            ViewBag.BloodListId = new SelectList(db.BloodStocks, "BloodListId", "BloodName");
            return View();
        }

        // POST: RequestBloods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequestId,Name,BloodListId,BloodId,RequestDate,Age,Gender,Address,ContactNo")] RequestBlood requestBlood)
        {
            if (ModelState.IsValid)
            {
                db.RequestBloods.Add(requestBlood);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BloodId = new SelectList(db.BloodDetails, "BloodId", "BloodDescription", requestBlood.BloodId);
            ViewBag.BloodListId = new SelectList(db.BloodStocks, "BloodListId", "BloodName", requestBlood.BloodListId);
            return View(requestBlood);
        }

        // GET: RequestBloods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestBlood requestBlood = db.RequestBloods.Find(id);
            if (requestBlood == null)
            {
                return HttpNotFound();
            }
            ViewBag.BloodId = new SelectList(db.BloodDetails, "BloodId", "BloodDescription", requestBlood.BloodId);
            ViewBag.BloodListId = new SelectList(db.BloodStocks, "BloodListId", "BloodName", requestBlood.BloodListId);
            return View(requestBlood);
        }

        // POST: RequestBloods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequestId,Name,BloodListId,BloodId,RequestDate,Age,Gender,Address,ContactNo")] RequestBlood requestBlood)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requestBlood).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BloodId = new SelectList(db.BloodDetails, "BloodId", "BloodDescription", requestBlood.BloodId);
            ViewBag.BloodListId = new SelectList(db.BloodStocks, "BloodListId", "BloodName", requestBlood.BloodListId);
            return View(requestBlood);
        }

        // GET: RequestBloods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestBlood requestBlood = db.RequestBloods.Find(id);
            if (requestBlood == null)
            {
                return HttpNotFound();
            }
            return View(requestBlood);
        }

        // POST: RequestBloods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RequestBlood requestBlood = db.RequestBloods.Find(id);
            db.RequestBloods.Remove(requestBlood);
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
