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
        private bDBContext db = new bDBContext();

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

            return View();
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
    }
}