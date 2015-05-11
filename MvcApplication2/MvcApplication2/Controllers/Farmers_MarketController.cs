using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class Farmers_MarketController : Controller
    {
        private db254614719227434d8463a494003807b5Entities db = new db254614719227434d8463a494003807b5Entities();

        //
        // GET: /Farmers_Market/

        public ActionResult Index()
        {
            var farmers_market = db.FARMERS_MARKET.Include(f => f.PROPIETOR);
            return View(farmers_market.ToList());
        }

        //
        // GET: /Farmers_Market/Details/5

        public ActionResult Details(string id = null)
        {
            FARMERS_MARKET farmers_market = db.FARMERS_MARKET.Find(id);
            if (farmers_market == null)
            {
                return HttpNotFound();
            }
            return View(farmers_market);
        }

        //
        // GET: /Farmers_Market/Create

        public ActionResult Create()
        {
            ViewBag.ProprietorId = new SelectList(db.PROPIETORs, "ProprietorId", "FName");
            return View();
        }

        //
        // POST: /Farmers_Market/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FARMERS_MARKET farmers_market)
        {
            if (ModelState.IsValid)
            {
                db.FARMERS_MARKET.Add(farmers_market);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProprietorId = new SelectList(db.PROPIETORs, "ProprietorId", "FName", farmers_market.ProprietorId);
            return View(farmers_market);
        }

        //
        // GET: /Farmers_Market/Edit/5

        public ActionResult Edit(string id = null)
        {
            FARMERS_MARKET farmers_market = db.FARMERS_MARKET.Find(id);
            if (farmers_market == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProprietorId = new SelectList(db.PROPIETORs, "ProprietorId", "FName", farmers_market.ProprietorId);
            return View(farmers_market);
        }

        //
        // POST: /Farmers_Market/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FARMERS_MARKET farmers_market)
        {
            if (ModelState.IsValid)
            {
                db.Entry(farmers_market).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProprietorId = new SelectList(db.PROPIETORs, "ProprietorId", "FName", farmers_market.ProprietorId);
            return View(farmers_market);
        }

        //
        // GET: /Farmers_Market/Delete/5

        public ActionResult Delete(string id = null)
        {
            FARMERS_MARKET farmers_market = db.FARMERS_MARKET.Find(id);
            if (farmers_market == null)
            {
                return HttpNotFound();
            }
            return View(farmers_market);
        }

        //
        // POST: /Farmers_Market/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            FARMERS_MARKET farmers_market = db.FARMERS_MARKET.Find(id);
            db.FARMERS_MARKET.Remove(farmers_market);
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