using b.Filters;
using b.Models;
//using Ext.Net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;

namespace b.Controllers
{
    public class PurchaseController : BaseController
    {
        protected PurchaseOrder curPO;
        protected Vendor curVendor;
        public ActionResult Index()
        {
            //X.Msg.Alert("great", "creating data").Show();
            var lastVersions = from n in db.Purchases
                               group n by n.ID into g
                               select g.OrderByDescending(t => t.Version).FirstOrDefault();
            //X.Msg.Notify("great", "loading to view").Show();
            return View();
            //return View(lastVersions.ToList());
        }
        public ActionResult Details(int id = 0, int version = 0)
        {
            Purchase purchase = db.Purchases.Find(id, version);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        public ActionResult Create()
        {
            // this is to be taken care of when there is no need to do other things
            // what this looks like is the fact that it will take coare of itself
            //Purchase newPurchase = new Purchase { Date = DateTime.Today, PurchaseItems = new List<PurchaseItem>() };
            Purchase newPurchase = new Purchase { Date = DateTime.Today, PurchaseItems = new List<PurchaseItem> { new PurchaseItem { ProductID = 1, Qty = 1, Rate = 1 } } };
            //return View(new Purchase { Date = DateTime.Today, PurchaseItems = new List<PurchaseItem> { new PurchaseItem { ProductID = 1, Qty = 1, Rate = 1 } } });
            CreateProductsList();
            CreatePoList(newPurchase);
            CreateVendorsList(newPurchase);

            return View(newPurchase);
        }
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

        public ActionResult Edit(int id = 0, int version = 0)
        {
            Purchase purchase = db.Purchases.Find(id, version);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                Purchase newItem = purchase;
                newItem.Version = purchase.Version + 1;
                newItem.EntryDate = DateTime.Now;
                db.Purchases.Add(newItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(purchase);
        }

        public ActionResult Delete(int id = 0, int version = 0)
        {
            Purchase purchase = db.Purchases.Find(id, version);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int version = 0)
        {
            var itemsToDelete = db.Purchases.Where(t => t.ID == id);
            foreach (var item in itemsToDelete)
            {
                if (item != null) db.Purchases.Remove(item);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ChangePO(int id)
        {
            curPO = GetPO(id);
            curVendor = GetPOVendor(curPO.VendorID);
            return Json(curVendor, JsonRequestBehavior.AllowGet);
        }
    }
}