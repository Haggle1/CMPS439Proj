using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class GoodController : Controller
    {
        private db254614719227434d8463a494003807b5Entities db = new db254614719227434d8463a494003807b5Entities();

        //
        // GET: /Good/

        public ActionResult Index()
        {
            var goods = db.GOODs.Include(g => g.DEPARTMENT);
            return View(goods.ToList());
        }

        //
        // GET: /Good/Details/5

        public ActionResult Details(int id = 0)
        {
            GOOD good = db.GOODs.Find(id);
            if (good == null)
            {
                return HttpNotFound();
            }
            return View(good);
        }

        //
        // GET: /Good/Create

        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.DEPARTMENTs, "DepartmentId", "Name");
            return View();
        }

        //
        // POST: /Good/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GOOD good)
        {
            if (ModelState.IsValid)
            {
                db.GOODs.Add(good);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.DEPARTMENTs, "DepartmentId", "Name", good.DepartmentId);
            return View(good);
        }

        //
        // GET: /Good/Edit/5

        public ActionResult Edit(int id = 0)
        {
            GOOD good = db.GOODs.Find(id);
            if (good == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.DEPARTMENTs, "DepartmentId", "Name", good.DepartmentId);
            return View(good);
        }

        //
        // POST: /Good/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GOOD good)
        {
            if (ModelState.IsValid)
            {
                db.Entry(good).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.DEPARTMENTs, "DepartmentId", "Name", good.DepartmentId);
            return View(good);
        }

        //
        // GET: /Good/Delete/5

        public ActionResult Delete(int id = 0)
        {
            GOOD good = db.GOODs.Find(id);
            if (good == null)
            {
                return HttpNotFound();
            }
            return View(good);
        }

        //
        // POST: /Good/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GOOD good = db.GOODs.Find(id);
            db.GOODs.Remove(good);
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