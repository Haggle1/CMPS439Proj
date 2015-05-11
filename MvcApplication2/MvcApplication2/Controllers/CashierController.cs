using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class CashierController : Controller
    {
        private db254614719227434d8463a494003807b5Entities db = new db254614719227434d8463a494003807b5Entities();

        //
        // GET: /Cashier/

        public ActionResult Index()
        {
            var cashiers = db.CASHIERs.Include(c => c.FARMERS_MARKET).Include(c => c.PROPIETOR);
            return View(cashiers.ToList());
        }

        //
        // GET: /Cashier/Details/5

        public ActionResult Details(int id = 0)
        {
            CASHIER cashier = db.CASHIERs.Find(id);
            if (cashier == null)
            {
                return HttpNotFound();
            }
            return View(cashier);
        }

        //
        // GET: /Cashier/Create

        public ActionResult Create()
        {
            ViewBag.FMName = new SelectList(db.FARMERS_MARKET, "FMName", "Address");
            ViewBag.ProprietorId = new SelectList(db.PROPIETORs, "ProprietorId", "FName");
            return View();
        }

        //
        // POST: /Cashier/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CASHIER cashier)
        {
            if (ModelState.IsValid)
            {
                db.CASHIERs.Add(cashier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FMName = new SelectList(db.FARMERS_MARKET, "FMName", "Address", cashier.FMName);
            ViewBag.ProprietorId = new SelectList(db.PROPIETORs, "ProprietorId", "FName", cashier.ProprietorId);
            return View(cashier);
        }

        //
        // GET: /Cashier/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CASHIER cashier = db.CASHIERs.Find(id);
            if (cashier == null)
            {
                return HttpNotFound();
            }
            ViewBag.FMName = new SelectList(db.FARMERS_MARKET, "FMName", "Address", cashier.FMName);
            ViewBag.ProprietorId = new SelectList(db.PROPIETORs, "ProprietorId", "FName", cashier.ProprietorId);
            return View(cashier);
        }

        //
        // POST: /Cashier/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CASHIER cashier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cashier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FMName = new SelectList(db.FARMERS_MARKET, "FMName", "Address", cashier.FMName);
            ViewBag.ProprietorId = new SelectList(db.PROPIETORs, "ProprietorId", "FName", cashier.ProprietorId);
            return View(cashier);
        }

        //
        // GET: /Cashier/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CASHIER cashier = db.CASHIERs.Find(id);
            if (cashier == null)
            {
                return HttpNotFound();
            }
            return View(cashier);
        }

        //
        // POST: /Cashier/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CASHIER cashier = db.CASHIERs.Find(id);
            db.CASHIERs.Remove(cashier);
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