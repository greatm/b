using b.Models;
using b.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace b.Controllers
{
    public class SalesOrderController : Controller
    {
        private bDBContext db = new bDBContext();
        public ActionResult Index()
        {
            return View(db.SalesOrders.ToList());
        }
        public ActionResult Details(int id = 0)
        {
            SalesOrder salesorder = db.SalesOrders.Find(id);
            if (salesorder == null)
            {
                return HttpNotFound();
            }
            return View(salesorder);
        }
        public ActionResult Create()
        {
            //SalesOrder newSO = new SalesOrder { Date = DateTime.Today, SalesOrderItems = new List<SalesOrderItem> { new SalesOrderItem { Qty = 10 } } };
            SalesOrder newSO = new SalesOrder { Date = DateTime.Today, SalesOrderItems = new List<SalesOrderItem>() };
            SalesOrderItem soItem = new SalesOrderItem();
            CreateProductsList(soItem);
            newSO.SalesOrderItems.Add(soItem);
            CreateCustomersList(newSO);
            return View(newSO);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SalesOrder salesorder)
        {
            if (ModelState.IsValid)
            {
                db.SalesOrders.Add(salesorder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            CreateCustomersList(salesorder);
            return View(salesorder);
        }
        public ActionResult Edit(int id = 0)
        {
            SalesOrder salesorder = db.SalesOrders.Find(id);
            if (salesorder == null)
            {
                return HttpNotFound();
            }
            return View(salesorder);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SalesOrder salesorder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesorder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salesorder);
        }
        public ActionResult Delete(int id = 0)
        {
            SalesOrder salesorder = db.SalesOrders.Find(id);
            if (salesorder == null)
            {
                return HttpNotFound();
            }
            return View(salesorder);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalesOrder salesorder = db.SalesOrders.Find(id);
            db.SalesOrders.Remove(salesorder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private void CreateCustomersList(SalesOrder workSO)
        {
            var customers = db.Customers;
            List<object> newList = new List<object>();
            foreach (var customer in customers)
                newList.Add(new
                {
                    Id = customer.ID,
                    Name = customer.FirstName + " " + customer.LastName
                });
            this.ViewData["CustomerID"] = new SelectList(newList, "Id", "Name", workSO.CustomerID);

        }
        private void CreateProductsList(SalesOrderItem workSOitem)
        {
            this.ViewData["ProductID"] = new SelectList(db.Products, "Id", "Name", workSOitem.ProductID);
        }
    }
}