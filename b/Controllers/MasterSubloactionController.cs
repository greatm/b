using b.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System;

namespace b.Controllers
{
    public class MasterSubloactionController : Controller
    {
        private bDBContext db = new bDBContext();
        public ActionResult Index()
        {
            var lastVersions = from n in db.Sublocations
                               group n by n.ID into g
                               select g.OrderByDescending(t => t.Version).FirstOrDefault();
            return View(lastVersions.ToList());
            //return View(db.Sublocations.Include(t => t.Store).ToList());
        }
        public ActionResult Details(int id = 0, int version = 0)
        {
            Sublocation sublocation = db.Sublocations.Find(id, version);
            if (sublocation == null)
            {
                return HttpNotFound();
            }
            return View(sublocation);
        }
        public ActionResult Create()
        {
            Sublocation newSloc = new Sublocation();
            CreateStoreDDitems(newSloc);
            return View(newSloc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sublocation sublocation)
        {
            if (ModelState.IsValid)
            {
                int iId = 1;
                try
                {
                    iId = db.Sublocations.Max(t => t.ID) + 1;
                }
                catch { }
                sublocation.ID = iId;
                sublocation.Version = 1;
                sublocation.EntryDate = DateTime.Now;
                db.Sublocations.Add(sublocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            CreateStoreDDitems(sublocation);
            return View(sublocation);
        }

        //
        // GET: /MasterSubloaction/Edit/5

        public ActionResult Edit(int id = 0, int version = 0)
        {
            Sublocation sublocation = db.Sublocations.Find(id, version);
            if (sublocation == null)
            {
                return HttpNotFound();
            }
            CreateStoreDDitems(sublocation);
            return View(sublocation);
        }

        private void CreateStoreDDitems(Sublocation sublocation)
        {
            ViewBag.StoreID = new SelectList(db.Stores, "Id", "Name", sublocation.StoreID);
            //this.ViewData["StoreID"] = new SelectList(db.Stores, "Id", "Name", sublocation.StoreID);
        }

        //
        // POST: /MasterSubloaction/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sublocation sublocation)
        {
            if (ModelState.IsValid)
            {
                Sublocation newItem = sublocation;
                newItem.Version = sublocation.Version + 1;
                newItem.EntryDate = DateTime.Now;
                db.Entry(sublocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            CreateStoreDDitems(sublocation);
            //this.ViewData["StoreID"] = new SelectList(db.Stores, "Id", "Name");
            return View(sublocation);
        }

        //
        // GET: /MasterSubloaction/Delete/5

        public ActionResult Delete(int id = 0, int version = 0)
        {
            Sublocation sublocation = db.Sublocations.Find(id, version);
            if (sublocation == null)
            {
                return HttpNotFound();
            }
            return View(sublocation);
        }

        //
        // POST: /MasterSubloaction/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int version)
        {
            //Sublocation sublocation = db.Sublocations.Find(id);
            //db.Sublocations.Remove(sublocation);
            var itemsToDelete = db.Sublocations.Where(t => t.ID == id);
            foreach (var item in itemsToDelete)
            {
                if (item != null) db.Sublocations.Remove(item);
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