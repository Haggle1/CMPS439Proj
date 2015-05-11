using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class Sales_AssociateController : Controller
    {
        private db254614719227434d8463a494003807b5Entities db = new db254614719227434d8463a494003807b5Entities();

        //
        // GET: /Sales_Associate/

        public ActionResult Index()
        {
            var sales_associate = db.SALES_ASSOCIATE.Include(s => s.FARMERS_MARKET).Include(s => s.PROPIETOR);
            return View(sales_associate.ToList());
        }

        //
        // GET: /Sales_Associate/Details/5

        public ActionResult Details(int id = 0)
        {
            SALES_ASSOCIATE sales_associate = db.SALES_ASSOCIATE.Find(id);
            if (sales_associate == null)
            {
                return HttpNotFound();
            }
            return View(sales_associate);
        }

        //
        // GET: /Sales_Associate/Create

        public ActionResult Create()
        {
            ViewBag.FMName = new SelectList(db.FARMERS_MARKET, "FMName", "Address");
            ViewBag.ProprietorId = new SelectList(db.PROPIETORs, "ProprietorId", "FName");
            return View();
        }

        //
        // POST: /Sales_Associate/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SALES_ASSOCIATE sales_associate)
        {
            if (ModelState.IsValid)
            {
                db.SALES_ASSOCIATE.Add(sales_associate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FMName = new SelectList(db.FARMERS_MARKET, "FMName", "Address", sales_associate.FMName);
            ViewBag.ProprietorId = new SelectList(db.PROPIETORs, "ProprietorId", "FName", sales_associate.ProprietorId);
            return View(sales_associate);
        }

        //
        // GET: /Sales_Associate/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SALES_ASSOCIATE sales_associate = db.SALES_ASSOCIATE.Find(id);
            if (sales_associate == null)
            {
                return HttpNotFound();
            }
            ViewBag.FMName = new SelectList(db.FARMERS_MARKET, "FMName", "Address", sales_associate.FMName);
            ViewBag.ProprietorId = new SelectList(db.PROPIETORs, "ProprietorId", "FName", sales_associate.ProprietorId);
            return View(sales_associate);
        }

        //
        // POST: /Sales_Associate/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SALES_ASSOCIATE sales_associate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sales_associate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FMName = new SelectList(db.FARMERS_MARKET, "FMName", "Address", sales_associate.FMName);
            ViewBag.ProprietorId = new SelectList(db.PROPIETORs, "ProprietorId", "FName", sales_associate.ProprietorId);
            return View(sales_associate);
        }

        //
        // GET: /Sales_Associate/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SALES_ASSOCIATE sales_associate = db.SALES_ASSOCIATE.Find(id);
            if (sales_associate == null)
            {
                return HttpNotFound();
            }
            return View(sales_associate);
        }

        //
        // POST: /Sales_Associate/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SALES_ASSOCIATE sales_associate = db.SALES_ASSOCIATE.Find(id);
            db.SALES_ASSOCIATE.Remove(sales_associate);
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