using b.Models;
using b.ViewModels;
using System.Data;
using System.Data.Objects;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System;

namespace b.Controllers
{
    public class MasterSublocationController : BaseController2
    {
        public ActionResult Index()
        {
            var lastVersions = rb.AllV<Sublocation>();
            var DisplayItems = from lpo in lastVersions
                               join stor in
                                   (
                                       from n in rb.AllV<Store>()
                                       group n by n.ID into g
                                       select g.OrderByDescending(t => t.Version).FirstOrDefault()
                                       )
                               on lpo.StoreID equals stor.ID
                               select new SublocationStore
                               {
                                   Sublocation = lpo,
                                   Store = stor
                               }
                            ;
            return View(DisplayItems.ToList());
        }
        public ActionResult Details(int id = 0, int version = 0)
        {
            //Sublocation sublocation = db.Sublocations.Find(id, version);
            Sublocation sublocation = rb.Find<Sublocation>(id, version);
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
                //int iId = 1;
                //try
                //{
                //    iId = db.Sublocations.Max(t => t.ID) + 1;
                //}
                //catch { }
                //sublocation.ID = iId;
                //sublocation.Version = 1;
                //sublocation.EntryDate = DateTime.Now;
                //db.Sublocations.Add(sublocation);
                //db.SaveChanges();
                rb.Create<Sublocation>(sublocation);
                return RedirectToAction("Index");
            }

            CreateStoreDDitems(sublocation);
            return View(sublocation);
        }

        public ActionResult Edit(int id = 0, int version = 0)
        {
            //Sublocation sublocation = db.Sublocations.Find(id, version);
            Sublocation sublocation = rb.Find<Sublocation>(id, version);
            if (sublocation == null)
            {
                return HttpNotFound();
            }
            CreateStoreDDitems(sublocation);
            return View(sublocation);
        }
        private void CreateStoreDDitems(Sublocation sublocation)
        {
            ViewBag.StoreID = new SelectList(rb.AllV<Store>(), "Id", "Name", sublocation.StoreID);
            //ViewBag.StoreID = new SelectList(rb.GetStores(), "Id", "Name", sublocation.StoreID);
            //ViewBag.StoreID = new SelectList(db.Stores, "Id", "Name", sublocation.StoreID);
            //this.ViewData["StoreID"] = new SelectList(db.Stores, "Id", "Name", sublocation.StoreID);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sublocation sublocation)
        {
            if (ModelState.IsValid)
            {
                //Sublocation newItem = sublocation;
                //newItem.Version = sublocation.Version + 1;
                //newItem.EntryDate = DateTime.Now;
                //db.Sublocations.Add(newItem);
                //db.SaveChanges();
                rb.Edit<Sublocation>(sublocation);
                return RedirectToAction("Index");
            }
            CreateStoreDDitems(sublocation);
            //this.ViewData["StoreID"] = new SelectList(db.Stores, "Id", "Name");
            return View(sublocation);
        }

        public ActionResult Delete(int id = 0, int version = 0)
        {
            //Sublocation sublocation = db.Sublocations.Find(id, version);
            Sublocation sublocation = rb.Find<Sublocation>(id, version);
            if (sublocation == null)
            {
                return HttpNotFound();
            }
            return View(sublocation);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int version)
        {
            //Sublocation sublocation = db.Sublocations.Find(id);
            //db.Sublocations.Remove(sublocation);

            //var itemsToDelete = db.Sublocations.Where(t => t.ID == id);
            //foreach (var item in itemsToDelete)
            //{
            //    if (item != null) db.Sublocations.Remove(item);
            //}
            //db.SaveChanges();
            rb.Delete<Sublocation>(t => t.ID == id);

            return RedirectToAction("Index");
        }
    }
}