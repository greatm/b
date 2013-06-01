using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using b.Models;
using b.ViewModels;

namespace b.Controllers
{
    public class MasterCustomerController : Controller
    {
        private bDBContext db = new bDBContext();

        //
        // GET: /MasterCustomer/

        public ActionResult Index()
        {
            return View(db.Customers.ToList().Select(t => new CustomerSummary { Name = t.FirstName + " " + t.LastName, Active = t.Active.ToString(), ServiceLevel = t.ServiceLevel.ToString() }));
        }

        //
        // GET: /MasterCustomer/Details/5

        public ActionResult Details(int id = 0, int version = 0)
        {
            Customer customer = db.Customers.Find(id, version);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //
        // GET: /MasterCustomer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MasterCustomer/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                int iId = 1;
                try
                {
                    iId = db.Customers.Max(t => t.ID) + 1;
                }
                catch { }
                customer.ID = iId;
                customer.Version = 1;
                customer.EntryDate = DateTime.Now;
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        //
        // GET: /MasterCustomer/Edit/5

        public ActionResult Edit(int id = 0, int version = 0)
        {
            Customer customer = db.Customers.Find(id, version);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //
        // POST: /MasterCustomer/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                Customer newItem = customer;
                newItem.Version = customer.Version + 1;
                newItem.EntryDate = DateTime.Now;
                db.Customers.Add(newItem);
                //db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        //
        // GET: /MasterCustomer/Delete/5

        public ActionResult Delete(int id = 0, int version = 0)
        {
            Customer customer = db.Customers.Find(id, version);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //
        // POST: /MasterCustomer/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int version = 0)
        {
            //Customer customer = db.Customers.Find(id, version);
            //db.Customers.Remove(customer);
            var itemsToDelete = db.Customers.Where(t => t.ID == id);
            foreach (var item in itemsToDelete)
            {
                if (item != null) db.Customers.Remove(item);
            }
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