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
    public class SalesController : BaseController
    {
        public ActionResult Index()
        {
            var lastVersions = from n in db.Sales
                               group n by n.ID into g
                               select g.OrderByDescending(t => t.Version).FirstOrDefault();
            return View(lastVersions.ToList());
            //return View(db.Sales.ToList());
        }
        public ActionResult Details(int id = 0, int version = 0)
        {
            Sales sales = db.Sales.Find(id, version);
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

        public ActionResult Edit(int id = 0, int version = 0)
        {
            Sales sales = db.Sales.Find(id, version);
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

        public ActionResult Delete(int id = 0, int version = 0)
        {
            Sales sales = db.Sales.Find(id, version);
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
        public ActionResult DeleteConfirmed(int id, int version = 0)
        {
            //Sales sales = db.Sales.Find(id, version);
            //db.Sales.Remove(sales);
            var itemsToDelete = db.Sales.Where(t => t.ID == id);
            foreach (var item in itemsToDelete)
            {
                if (item != null) db.Sales.Remove(item);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}