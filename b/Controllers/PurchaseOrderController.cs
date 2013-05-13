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
            PurchaseOrder newPO = new PurchaseOrder { Date = DateTime.Today, POItems = new List<POItem>() };
            foreach (Product prd in db.Products)
            {
                if (prd.RoL > 5)
                {
                    newPO.POItems.Add(new POItem { ProductID = prd.ID, Qty = prd.RoQ });
                }
            }
            if (newPO.POItems.Count < 1)
            {
                newPO.POItems.Add(new POItem());
            }
            CreateVendorsList(newPO);
            CreateProductsList();
            return View(newPO);
        }

        //
        // POST: /PurchaseOrder/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [IsPostedFromThisSite]
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
            //PurchaseOrder purchaseorder = db.PurchaseOrders.Find(id);
            PurchaseOrder purchaseorder = db.PurchaseOrders.Include(t=>t.POItems ).FirstOrDefault(t=>t.ID== id);
            if (purchaseorder == null)
            {
                return HttpNotFound();
            }

            CreateVendorsList(purchaseorder);
            CreateProductsList();

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
            CreateVendorsList(purchaseorder);
            CreateProductsList();
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
        private void CreateVendorsList(PurchaseOrder workPO)
        {
            var vendors = db.Vendors;
            List<object> newList = new List<object>();
            foreach (var vendor in vendors)
                newList.Add(new
                {
                    Id = vendor.ID,
                    Name = vendor.Name + " : " + vendor.Person
                });
            this.ViewData["VendorID"] = new SelectList(newList, "Id", "Name", workPO.VendorID);

        }
        private void CreateProductsList()
        {
            //var products = db.Products;
            //List<object> newList = new List<object>();
            //foreach (var vendor in products)
            //    newList.Add(new
            //    {
            //        Id = vendor.ID,
            //        Name = vendor.Name + " : " + vendor.Person
            //    });
            //this.ViewData["ProductID"] = new SelectList(db.Products, "Id", "Name");
            this.ViewData["Products"] = new SelectList(db.Products, "Id", "Name");

        }
        #endregion
    }
}