using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class PropietorController : Controller
    {
        private db254614719227434d8463a494003807b5Entities db = new db254614719227434d8463a494003807b5Entities();

        //
        // GET: /Propietor/

        public ActionResult Index()
        {
            return View(db.PROPIETORs.ToList());
        }

        //
        // GET: /Propietor/Details/5

        public ActionResult Details(int id = 0)
        {
            PROPIETOR propietor = db.PROPIETORs.Find(id);
            if (propietor == null)
            {
                return HttpNotFound();
            }
            return View(propietor);
        }

        //
        // GET: /Propietor/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Propietor/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PROPIETOR propietor)
        {
            if (ModelState.IsValid)
            {
                db.PROPIETORs.Add(propietor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(propietor);
        }

        //
        // GET: /Propietor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PROPIETOR propietor = db.PROPIETORs.Find(id);
            if (propietor == null)
            {
                return HttpNotFound();
            }
            return View(propietor);
        }

        //
        // POST: /Propietor/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PROPIETOR propietor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propietor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(propietor);
        }

        //
        // GET: /Propietor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PROPIETOR propietor = db.PROPIETORs.Find(id);
            if (propietor == null)
            {
                return HttpNotFound();
            }
            return View(propietor);
        }

        //
        // POST: /Propietor/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PROPIETOR propietor = db.PROPIETORs.Find(id);
            db.PROPIETORs.Remove(propietor);
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