using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class CustodianController : Controller
    {
        private db254614719227434d8463a494003807b5Entities db = new db254614719227434d8463a494003807b5Entities();

        //
        // GET: /Custodian/

        public ActionResult Index()
        {
            var custodians = db.CUSTODIANs.Include(c => c.FARMERS_MARKET).Include(c => c.PROPIETOR);
            return View(custodians.ToList());
        }

        //
        // GET: /Custodian/Details/5

        public ActionResult Details(int id = 0)
        {
            CUSTODIAN custodian = db.CUSTODIANs.Find(id);
            if (custodian == null)
            {
                return HttpNotFound();
            }
            return View(custodian);
        }

        //
        // GET: /Custodian/Create

        public ActionResult Create()
        {
            ViewBag.FMName = new SelectList(db.FARMERS_MARKET, "FMName", "Address");
            ViewBag.ProprietorId = new SelectList(db.PROPIETORs, "ProprietorId", "FName");
            return View();
        }

        //
        // POST: /Custodian/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CUSTODIAN custodian)
        {
            if (ModelState.IsValid)
            {
                db.CUSTODIANs.Add(custodian);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FMName = new SelectList(db.FARMERS_MARKET, "FMName", "Address", custodian.FMName);
            ViewBag.ProprietorId = new SelectList(db.PROPIETORs, "ProprietorId", "FName", custodian.ProprietorId);
            return View(custodian);
        }

        //
        // GET: /Custodian/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CUSTODIAN custodian = db.CUSTODIANs.Find(id);
            if (custodian == null)
            {
                return HttpNotFound();
            }
            ViewBag.FMName = new SelectList(db.FARMERS_MARKET, "FMName", "Address", custodian.FMName);
            ViewBag.ProprietorId = new SelectList(db.PROPIETORs, "ProprietorId", "FName", custodian.ProprietorId);
            return View(custodian);
        }

        //
        // POST: /Custodian/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CUSTODIAN custodian)
        {
            if (ModelState.IsValid)
            {
                db.Entry(custodian).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FMName = new SelectList(db.FARMERS_MARKET, "FMName", "Address", custodian.FMName);
            ViewBag.ProprietorId = new SelectList(db.PROPIETORs, "ProprietorId", "FName", custodian.ProprietorId);
            return View(custodian);
        }

        //
        // GET: /Custodian/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CUSTODIAN custodian = db.CUSTODIANs.Find(id);
            if (custodian == null)
            {
                return HttpNotFound();
            }
            return View(custodian);
        }

        //
        // POST: /Custodian/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CUSTODIAN custodian = db.CUSTODIANs.Find(id);
            db.CUSTODIANs.Remove(custodian);
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