using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using b.Models;

namespace b.Controllers
{
    public class MasterVendorController : Controller
    {
        private bDBContext db = new bDBContext();

        //
        // GET: /MasterVendor/

        public ActionResult Index()
        {
            return View(db.Vendors.ToList());
        }

        //
        // GET: /MasterVendor/Details/5

        public ActionResult Details(int id = 0)
        {
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        //
        // GET: /MasterVendor/Create

        public ActionResult Create()
        {
            return View(new Vendor {Version=1 });
        }

        //
        // POST: /MasterVendor/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                vendor.Version = 1;
                db.Vendors.Add(vendor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vendor);
        }

        //
        // GET: /MasterVendor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        //
        // POST: /MasterVendor/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vendor);
        }

        //
        // GET: /MasterVendor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        //
        // POST: /MasterVendor/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vendor vendor = db.Vendors.Find(id);
            db.Vendors.Remove(vendor);
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