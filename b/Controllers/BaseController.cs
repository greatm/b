using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using b.Models;
using b.ViewModels;
using b.Filters;

namespace b.Controllers
{
    public class BaseController : Controller
    {
        #region var
        protected bDBContext db = new bDBContext();
        #endregion

        #region action
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        #endregion

        #region function
        //private void CreateVendorsList()
        //{
        //    var vendors = db.Vendors;
        //    List<object> newList = new List<object>();
        //    foreach (var vendor in vendors)
        //        newList.Add(new
        //        {
        //            Id = vendor.ID,
        //            Name = vendor.Name + " : " + vendor.Person
        //        });
        //    this.ViewData["Vendors"] = new SelectList(newList, "Id", "Name");

        //}
        protected void CreatePoList(Purchase purchase)
        {
            var poes = from n in db.PurchaseOrders
                       group n by n.ID into g
                       select g.OrderByDescending(t => t.Version).FirstOrDefault();
            List<object> newList = new List<object>();
            foreach (var po in poes)
                newList.Add(new
                {
                    Id = po.ID,
                    Name = (po.Vendor == null ? "" : po.Vendor.Name + " : ") + po.ID
                });
            this.ViewData["POID"] = new SelectList(newList, "Id", "Name", purchase.POID);
        }
        protected PurchaseOrder GetPO(int id)
        {
            PurchaseOrder po = null;
            po = db.PurchaseOrders.OrderByDescending(t => t.Version).FirstOrDefault(t => t.ID == id);
            return po;
        }
        protected void CreateVendorsList(Purchase purchase)
        {
            var vendors = from n in db.Vendors
                          group n by n.ID into g
                          select g.OrderByDescending(t => t.Version).FirstOrDefault();
            List<object> newList = new List<object>();
            foreach (var vendor in vendors)
                newList.Add(new
                {
                    Id = vendor.ID,
                    Name = vendor.Name + " : " + vendor.Person
                });
            this.ViewData["VendorID"] = new SelectList(newList, "Id", "Name");
            //this.ViewData["VendorID"] = new SelectList(newList, "Id", "Name", purchase.VendorID);
        }
        #endregion
    }
}
