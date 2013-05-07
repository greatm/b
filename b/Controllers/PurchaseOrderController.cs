using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using b.ViewModels;
using b.Models;

namespace b.Controllers
{
    public class PurchaseOrderController : Controller
    {
        #region var

        private bDBContext db = new bDBContext();

        #endregion

        #region action
        //
        // GET: /PurchaseOrder/

        public ActionResult Index()
        {
            return View(db.PurchaseOrders.ToList());
        }

        //
        // GET: /PurchaseOrder/Details/5

        public ActionResult Details(int id = 0)
        {
            PurchaseOrder purchaseorder = db.PurchaseOrders.Find(id);
            if (purchaseorder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseorder);
        }

        //
        // GET: /PurchaseOrder/Create

        public ActionResult Create()
        {
            CreateVendorsList();
            //PurchaseOrder newPO = new PurchaseOrder { Date = DateTime.Today, POItems = new List<POItem> { new POItem { ProductID = 1, Qty = 1, Rate = 100 } } };
            PurchaseOrder newPO = new PurchaseOrder { Date = DateTime.Today, POItems = new List<POItem>() };
            foreach (Product prd in db.Products)
            {
                if (prd.RoL > 5)
                {
                    newPO.POItems.Add(new POItem { ProductID = prd.ID, Qty = prd.RoQ });
                }
            }
            return View(newPO);
        }

        //
        // POST: /PurchaseOrder/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PurchaseOrder purchaseorder)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseOrders.Add(purchaseorder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(purchaseorder);
        }

        public ActionResult POItemEntryRow()
        {
            return PartialView("POItemEntry");
        }

        //
        // GET: /PurchaseOrder/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PurchaseOrder purchaseorder = db.PurchaseOrders.Find(id);
            if (purchaseorder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseorder);
        }

        //
        // POST: /PurchaseOrder/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PurchaseOrder purchaseorder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseorder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(purchaseorder);
        }

        //
        // GET: /PurchaseOrder/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PurchaseOrder purchaseorder = db.PurchaseOrders.Find(id);
            if (purchaseorder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseorder);
        }

        //
        // POST: /PurchaseOrder/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseOrder purchaseorder = db.PurchaseOrders.Find(id);
            db.PurchaseOrders.Remove(purchaseorder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        #endregion

        #region function
        private void CreateVendorsList()
        {
            var vendors = db.Vendors;
            List<object> newList = new List<object>();
            foreach (var vendor in vendors)
                newList.Add(new
                {
                    Id = vendor.ID,
                    Name = vendor.Name + " : " + vendor.Person
                });
            this.ViewData["Vendors"] = new SelectList(newList, "Id", "Name");

        }
        #endregion
    }
}