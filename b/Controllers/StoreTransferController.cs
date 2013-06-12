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
    public class StoreTransferController : BaseController2
    {
        public ActionResult Index()
        {
            var lastVersions = rb.AllV<StoreTransfer>();
            return View(lastVersions.ToList());
        }
        public ActionResult Details(int id = 0, int version = 0)
        {
            //StoreTransfer storetransfer = db.StoreTransfers.Find(id);
            StoreTransfer storetransfer = rb.Find<StoreTransfer>(id, version);
            if (storetransfer == null)
            {
                return HttpNotFound();
            }
            return View(storetransfer);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StoreTransfer storetransfer)
        {
            if (ModelState.IsValid)
            {
                rb.Create<StoreTransfer>(storetransfer);
                return RedirectToAction("Index");
            }

            return View(storetransfer);
        }

        public ActionResult Edit(int id = 0, int version = 0)
        {
            StoreTransfer storetransfer = rb.Find<StoreTransfer>(id, version);
            //StoreTransfer storetransfer = db.StoreTransfers.Find(id);
            if (storetransfer == null)
            {
                return HttpNotFound();
            }
            return View(storetransfer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StoreTransfer storetransfer)
        {
            if (ModelState.IsValid)
            {
                rb.Edit<StoreTransfer>(storetransfer);
                //db.Entry(storetransfer).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(storetransfer);
        }

        public ActionResult Delete(int id = 0, int version = 0)
        {
            StoreTransfer storetransfer = rb.Find<StoreTransfer>(id, version);
            //StoreTransfer storetransfer = db.StoreTransfers.Find(id);
            if (storetransfer == null)
            {
                return HttpNotFound();
            }
            return View(storetransfer);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int version = 0)
        {
            rb.Delete<StoreTransfer>(t => t.ID == id);
            //StoreTransfer storetransfer = db.StoreTransfers.Find(id);
            //db.StoreTransfers.Remove(storetransfer);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}