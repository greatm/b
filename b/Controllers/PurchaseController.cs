using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using b.ViewModels;
using b.Models;
using b.Filters;

namespace b.Controllers
{
    public class PurchaseController : BaseController
    {
        public ActionResult Index()
        {
            return View(db.Purchases.ToList());
        }

        //
        // GET: /Purchase/Details/5

        public ActionResult Details(int id = 0, int version = 0)
        {
            Purchase purchase = db.Purchases.Find(id, version);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        //
        // GET: /Purchase/Create

        public ActionResult Create()
        {
            Purchase newPurchase = new Purchase { Date = DateTime.Today, PurchaseItems = new List<PurchaseItem> { new PurchaseItem { ProductID = 1, Qty = 1, Rate = 1 } } };
            //return View(new Purchase { Date = DateTime.Today, PurchaseItems = new List<PurchaseItem> { new PurchaseItem { ProductID = 1, Qty = 1, Rate = 1 } } });
            CreatePoList(newPurchase);
            CreateVendorsList(newPurchase);

            return View(newPurchase);
        }

        //
        // POST: /Purchase/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [IsPostedFromThisSite]
        public ActionResult Create(Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                int iId = 1;
                try
                {
                    iId = db.Purchases.Max(t => t.ID) + 1;
                }
                catch { }
                purchase.ID = iId;
                purchase.Version = 1;
                purchase.EntryDate = DateTime.Now;
                db.Purchases.Add(purchase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            CreatePoList(purchase);
            return View(purchase);
        }

        //
        // GET: /Purchase/Edit/5

        public ActionResult Edit(int id = 0, int version = 0)
        {
            Purchase purchase = db.Purchases.Find(id, version);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        //
        // POST: /Purchase/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(purchase);
        }

        //
        // GET: /Purchase/Delete/5

        public ActionResult Delete(int id = 0, int version = 0)
        {
            Purchase purchase = db.Purchases.Find(id, version);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        //
        // POST: /Purchase/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int version = 0)
        {
            Purchase purchase = db.Purchases.Find(id);
            db.Purchases.Remove(purchase);
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