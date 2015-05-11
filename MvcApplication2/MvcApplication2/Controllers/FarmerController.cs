using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class FarmerController : Controller
    {
        private db254614719227434d8463a494003807b5Entities db = new db254614719227434d8463a494003807b5Entities();

        //
        // GET: /Farmer/

        public ActionResult Index()
        {
            return View(db.FARMERs.ToList());
        }

        //
        // GET: /Farmer/Details/5

        public ActionResult Details(int id = 0)
        {
            FARMER farmer = db.FARMERs.Find(id);
            if (farmer == null)
            {
                return HttpNotFound();
            }
            return View(farmer);
        }

        //
        // GET: /Farmer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Farmer/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FARMER farmer)
        {
            if (ModelState.IsValid)
            {
                db.FARMERs.Add(farmer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(farmer);
        }

        //
        // GET: /Farmer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FARMER farmer = db.FARMERs.Find(id);
            if (farmer == null)
            {
                return HttpNotFound();
            }
            return View(farmer);
        }

        //
        // POST: /Farmer/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FARMER farmer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(farmer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(farmer);
        }

        //
        // GET: /Farmer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            FARMER farmer = db.FARMERs.Find(id);
            if (farmer == null)
            {
                return HttpNotFound();
            }
            return View(farmer);
        }

        //
        // POST: /Farmer/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FARMER farmer = db.FARMERs.Find(id);
            db.FARMERs.Remove(farmer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}