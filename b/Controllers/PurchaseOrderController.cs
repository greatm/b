using b.Filters;
using b.Models;
using b.ViewModels;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace b.Controllers
{
    public class PurchaseOrderController : BaseController
    {
        public ActionResult Index()
        {
            var lastVersions = from n in db.PurchaseOrders.Include(t => t.Vendor)
                               group n by n.ID into g
                               select g.OrderByDescending(t => t.Version).FirstOrDefault();
            return View(lastVersions.ToList());
        }
        public ActionResult Details(int id = 0, int version = 0)
        {
            PurchaseOrder purchaseorder = db.PurchaseOrders.Find(id, version);
            if (purchaseorder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseorder);
        }
        public ActionResult Create()
        {
            PurchaseOrder newPO = new PurchaseOrder { Date = DateTime.Today, POItems = new List<POItem>() };
            CreateProductsList();
            POItem poitem = null;
            var lastVersions = from n in db.Products
                               group n by n.ID into g
                               select g.OrderByDescending(t => t.Version).FirstOrDefault();
            foreach (Product prd in lastVersions)
            {
                if (prd.RoL > 5)
                {
                    poitem = new POItem { Product = prd, ProductID = prd.ID, Rate = prd.LastPurchaseRate, Qty = prd.RoQ, Amount = prd.LastPurchaseRate * prd.RoQ };
                    newPO.POItems.Add(poitem);
                }
            }
            if (newPO.POItems.Count < 1)
            {
                newPO.POItems.Add(new POItem());
            }
            CreateVendorsList(newPO);
            return View(newPO);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [IsPostedFromThisSite]
        public ActionResult Create(PurchaseOrder purchaseorder)
        {
            if (ModelState.IsValid)
            {
                int iId = 1;
                try
                {
                    iId = db.PurchaseOrders.Max(t => t.ID) + 1;
                }
                catch { }
                purchaseorder.ID = iId;
                purchaseorder.Version = 1;
                purchaseorder.EntryDate = DateTime.Now;
                db.PurchaseOrders.Add(purchaseorder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            CreateVendorsList(purchaseorder);
            foreach (POItem poItem in purchaseorder.POItems) CreateProductsList(poItem);
            return View(purchaseorder);
        }
        public ActionResult POItemEntryRow()
        {
            CreateProductsList(new POItem());
            return PartialView("POItemEntry");
        }
        public ActionResult Edit(int id = 0, int version = 0)
        {
            PurchaseOrder purchaseorder = db.PurchaseOrders.Find(id, version);
            if (purchaseorder == null)
            {
                return HttpNotFound();
            }

            CreateVendorsList(purchaseorder);

            db.Entry(purchaseorder).Collection(t => t.POItems).Load();
            foreach (POItem poitem in purchaseorder.POItems)
            {
                CreateProductsList(poitem);
            }

            return View(purchaseorder);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PurchaseOrder purchaseorder)
        {
            if (ModelState.IsValid)
            {
                PurchaseOrder newItem = purchaseorder;
                newItem.Version = purchaseorder.Version + 1;
                newItem.EntryDate = DateTime.Now;
                db.PurchaseOrders.Add(newItem);
                //db.Entry(purchaseorder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            CreateVendorsList(purchaseorder);
            //CreateProductsList();
            return View(purchaseorder);
        }
        public ActionResult PrintPO(int id = 0, int version = 0)
        {
            return new ActionAsPdf("Edit", new { id = id, version = version }) { FileName = "po_1.pdf" };
        }
        public ActionResult Delete(int id = 0, int version = 0)
        {
            PurchaseOrder purchaseorder = db.PurchaseOrders.Find(id, version);
            if (purchaseorder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseorder);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int version = 0)
        {
            //PurchaseOrder purchaseorder = db.PurchaseOrders.Find(id);
            //db.PurchaseOrders.Remove(purchaseorder);
            var itemsToDelete = db.PurchaseOrders.Where(t => t.ID == id);
            foreach (var item in itemsToDelete)
            {
                if (item != null) db.PurchaseOrders.Remove(item);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
      
        #region function
          #endregion
    }
}