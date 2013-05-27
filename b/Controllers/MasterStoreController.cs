using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using b.Models;

namespace b.Controllers
{
    public class MasterStoreController : Controller
    {
        private bDBContext db = new bDBContext();

        //
        // GET: /MasterStore/

        public ActionResult Index()
        {
            var lastVersions = from n in db.Stores
                               group n by n.ID into g
                               select g.OrderByDescending(t => t.Version).FirstOrDefault();
            return View(lastVersions.ToList());
        }

        //
        // GET: /MasterStore/Details/5

        public ActionResult Details(int id = 0, int version = 0)
        {
            Store store = db.Stores.Find(id, version);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        //
        // GET: /MasterStore/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MasterStore/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Store store)
        {
            if (ModelState.IsValid)
            {
                db.Stores.Add(store);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(store);
        }

        //
        // GET: /MasterStore/Edit/5

        public ActionResult Edit(int id = 0, int version = 0)
        {
            Store store = db.Stores.Find(id, version);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        //
        // POST: /MasterStore/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Store store)
        {
            if (ModelState.IsValid)
            {
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(store);
        }

        //
        // GET: /MasterStore/Delete/5

        public ActionResult Delete(int id = 0, int version = 0)
        {
            Store store = db.Stores.Find(id, version);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        //
        // POST: /MasterStore/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int version)
        {
            //Store store = db.Stores.Find(id, version);
            //db.Stores.Remove(store);
            var itemsToDelete = db.Stores.Where(t => t.ID == id);
            foreach (var item in itemsToDelete)
            {
                if (item != null) db.Stores.Remove(item);
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