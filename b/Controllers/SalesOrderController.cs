using b.Models;
using b.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace b.Controllers
{
    public class SalesOrderController : BaseController
    {
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
            //SalesOrder salesorder = db.SalesOrders.Find(id);
            //db.SalesOrders.Remove(salesorder);
            var itemsToDelete = db.SalesOrders.Where(t => t.ID == id);
            foreach (var item in itemsToDelete)
            {
                if (item != null) db.SalesOrders.Remove(item);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}