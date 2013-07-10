using b.Filters;
using b.Models;
using Syncfusion.Mvc.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcJqGrid;

namespace b.Controllers
{
    public class PurchaseController : RepoBaseController
    {
        protected PurchaseOrder curPO;
        protected Vendor curVendor;
        public ActionResult Index()
        {
            //X.Msg.Alert("great", "creating data").Show();
            var lastVersions = from n in rb.AllV<Purchase>() // db.Purchases
                               group n by n.ID into g
                               select g.OrderByDescending(t => t.Version).FirstOrDefault();
            //X.Msg.Notify("great", "loading to view").Show();
            // return View();
            return View(lastVersions.ToList());
        }
        public ActionResult Details(int id = 0, int version = 0)
        {
            //Purchase purchase = db.Purchases.Find(id, version);
            Purchase purchase = rb.Find<Purchase>(id, version);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        public ActionResult Create()
        {
            // this is to be taken care of when there is no need to do other things
            // what this looks like is the fact that it will take coare of itself
            //Purchase newPurchase = new Purchase { Date = DateTime.Today, PurchaseItems = new List<PurchaseItem>() };
            Purchase newPurchase = new Purchase { Date = DateTime.Today, PurchaseItems = new List<PurchaseItem> { new PurchaseItem { ProductID = 1, Qty = 1, Rate = 1 } } };
            //return View(new Purchase { Date = DateTime.Today, PurchaseItems = new List<PurchaseItem> { new PurchaseItem { ProductID = 1, Qty = 1, Rate = 1 } } });
            CreateProductsList();
            CreatePoList(newPurchase);
            CreateVendorsList(newPurchase);

            return View(newPurchase);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [IsPostedFromThisSite]
        public ActionResult Create(Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                //int iId = 1;
                //try
                //{
                //    iId = db.Purchases.Max(t => t.ID) + 1;
                //}
                //catch { }
                //purchase.ID = iId;
                //purchase.Version = 1;
                //purchase.EntryDate = DateTime.Now;
                //db.Purchases.Add(purchase);
                //db.SaveChanges();
                rb.Create<Purchase>(purchase);
                return RedirectToAction("Index");
            }

            CreatePoList(purchase);
            return View(purchase);
        }

        public ActionResult Edit(int id = 0, int version = 0)
        {
            Purchase purchase = rb.Find<Purchase>(id, version);
            //Purchase purchase = db.Purchases.Find(id, version);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                //Purchase newItem = purchase;
                //newItem.Version = purchase.Version + 1;
                //newItem.EntryDate = DateTime.Now;
                //db.Purchases.Add(newItem);
                //db.SaveChanges();
                rb.Edit<Purchase>(purchase);
                return RedirectToAction("Index");
            }
            return View(purchase);
        }

        public ActionResult Delete(int id = 0, int version = 0)
        {
            Purchase purchase = rb.Find<Purchase>(id, version);
            //Purchase purchase = db.Purchases.Find(id, version);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int version = 0)
        {
            //var itemsToDelete = db.Purchases.Where(t => t.ID == id);
            //foreach (var item in itemsToDelete)
            //{
            //    if (item != null) db.Purchases.Remove(item);
            //}
            //db.SaveChanges();
            rb.Delete<Purchase>(t => t.ID == id);
            return RedirectToAction("Index");
        }
        public ActionResult ChangePO(int id)
        {
            curPO = GetPO(id);
            ViewData["curPOid"] = curPO.ID;
            curVendor = GetPOVendor(curPO.VendorID);
            return Json(curVendor, JsonRequestBehavior.AllowGet);
        }
        public ActionResult FlatGrid()
        {
            GridPropertiesModel<PurchaseItem> model = new GridPropertiesModel<PurchaseItem>()
            {
                DataSource = curPO.POItems,// new NorthwindDataContext().Orders.Take(20).ToList(),
                //ShowCaption = false,
                AutoFormat = Syncfusion.Mvc.Shared.Skins.Marble

            };

            ViewData["GridModel"] = model;
            return View();

        }
        public ActionResult piGrid(GridSettings grid, int curPOid = 0)
        {
            if (curPOid < 1) return null;
            PurchaseOrder curPO = rb.AllV<PurchaseOrder>().FirstOrDefault(t => t.ID == curPOid);
            if (curPO == null || curPO.ID < 1) return null;
            rb.LoadCollection<PurchaseOrder>(curPO, "POItems");
            if (curPO.POItems == null) return null;
            var query = curPO.POItems.AsQueryable();

            //search
            if (grid.IsSearch)
            {
                foreach (var rule in grid.Where.rules)
                {
                    switch (rule.field)
                    {
                        case "ProductID":
                            query = query.Where(t => t.ProductID.ToString().Contains(rule.data));
                            break;
                        case "Amount":
                            query = query.Where(t => t.Amount.ToString().Contains(rule.data));
                            break;
                    }
                }
            }
            //sorting
            query = query.OrderBy<POItem>(grid.SortColumn, grid.SortOrder);
            //count
            var count = query.Count();
            //paging
            var data = query.Skip((grid.PageIndex - 1) * grid.PageSize).Take(grid.PageSize).ToArray();
            var result = new
            {
                total = (int)Math.Ceiling((double)count / grid.PageSize),
                page = grid.PageIndex,
                records = count,
                rows = (from poitem in data
                        select new
                        {
                            ProductID = poitem.ProductID,//.ToString(),
                            Quantity = poitem.Qty,
                            Rate = poitem.Rate,
                            Amount = poitem.Amount,
                        }).ToArray()
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}