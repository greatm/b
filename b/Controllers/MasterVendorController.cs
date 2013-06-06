using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using b.Models;
using StackExchange.Profiling;
using System.Threading;

namespace b.Controllers
{
    public class MasterVendorController : BaseController2
    {
        public ActionResult Index()
        {
            var lastVersionVendors = rb.All<Vendor>();
            //var lastVersionVendors = from n in db.Vendors
            //                         group n by n.ID into g
            //                         select g.OrderByDescending(t => t.Version).FirstOrDefault();
            return View(lastVersionVendors.ToList());
            //return View(db.Vendors.ToList());
        }

        public ActionResult Details(int id = 0, int version = 0)
        {
            //Vendor vendor = db.Vendors.Find(id, version);
            Vendor vendor = rb.Find<Vendor>(id, version);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        public ActionResult Create()
        {
            return View();
            //return View(new Vendor { Version = 1 });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                //int iId = 1;
                //try
                //{
                //    iId = db.Vendors.Max(t => t.ID) + 1;
                //}
                //catch { }
                //vendor.ID = iId;
                //vendor.Version = 1;
                //vendor.EntryDate = DateTime.Now;
                //db.Vendors.Add(vendor);
                //db.SaveChanges();
                rb.Create<Vendor>(vendor);
                return RedirectToAction("Index");
            }

            return View(vendor);
        }

        //
        // GET: /MasterVendor/Edit/5

        public ActionResult Edit(int id = 0, int version = 0)
        {
            //Vendor vendor = db.Vendors.Find(id, version);
            Vendor vendor = rb.Find<Vendor>(id, version);
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
                //Vendor newItem = vendor;
                //newItem.Version = vendor.Version + 1;
                //newItem.EntryDate = DateTime.Now;
                //db.Vendors.Add(newItem);
                //db.SaveChanges();
                rb.Edit<Vendor>(vendor);
                return RedirectToAction("Index");
            }
            return View(vendor);
        }

        //
        // GET: /MasterVendor/Delete/5

        public ActionResult Delete(int id = 0, int version = 0)
        {
            //Vendor vendor = db.Vendors.Find(id, version);
            Vendor vendor = rb.Find<Vendor>(id, version);
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
        public ActionResult DeleteConfirmed(int id, int version = 0)
        {
            rb.Delete<Vendor>(t => t.ID == id);
            //var itemsToDelete = db.Vendors.Where(t => t.ID == id);
            //foreach (var item in itemsToDelete)
            //{
            //    if (item != null) db.Vendors.Remove(item);
            //}

            //db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}