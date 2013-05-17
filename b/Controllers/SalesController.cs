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
    public class SalesController : Controller
    {
        private bDBContext db = new bDBContext();
        public ActionResult Index()
        {
            return View(db.Sales.ToList());
        }
        public ActionResult Details(int id = 0)
        {
            Sales sales = db.Sales.Find(id);
            if (sales == null)
            {
                return HttpNotFound();
            }
            return View(sales);
        }
        public ActionResult Create()
        {
            Sales newSales = new Sales { Date = DateTime.Today, SalesItems = new List<SalesItem>() };
            SalesItem soItem = new SalesItem();
            CreateProductsList(soItem);
            newSales.SalesItems.Add(soItem);
            CreateCustomersList(newSales);
            return View(newSales);

            //return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sales sales)
        {
            if (ModelState.IsValid)
            {
                db.Sales.Add(sales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sales);
        }

        //
        // GET: /Sales/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Sales sales = db.Sales.Find(id);
            if (sales == null)
            {
                return HttpNotFound();
            }
            return View(sales);
        }

        //
        // POST: /Sales/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sales sales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sales);
        }

        //
        // GET: /Sales/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Sales sales = db.Sales.Find(id);
            if (sales == null)
            {
                return HttpNotFound();
            }
            return View(sales);
        }

        //
        // POST: /Sales/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sales sales = db.Sales.Find(id);
            db.Sales.Remove(sales);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private void CreateCustomersList(Sales workSales)
        {
            var customers = db.Customers;
            List<object> newList = new List<object>();
            foreach (var customer in customers)
                newList.Add(new
                {
                    Id = customer.ID,
                    Name = customer.FirstName + " " + customer.LastName
                });
            this.ViewData["CustomerID"] = new SelectList(newList, "Id", "Name", workSales.CustomerID);
        }
        private void CreateProductsList(SalesItem workSalesItem)
        {
            this.ViewData["ProductID"] = new SelectList(db.Products, "Id", "Name", workSalesItem.ProductID);
        }
    }
}