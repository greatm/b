﻿using System;
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
        protected bDBContext db = new bDBContext();

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        protected void CreateVendorsList(PurchaseOrder workPO)
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
            this.ViewData["VendorID"] = new SelectList(newList, "Id", "Name", workPO.VendorID);

        }
        protected void CreateProductsList(POItem poItem)
        {
            var lastVersions = from n in db.Products
                               group n by n.ID into g
                               select g.OrderByDescending(t => t.Version).FirstOrDefault();
            this.ViewData["Products"] = new SelectList(lastVersions, "Id", "Name", poItem.ProductID);
        }
        protected void CreateProductsList()
        {
            var lastVersions = from n in db.Products
                               group n by n.ID into g
                               select g.OrderByDescending(t => t.Version).FirstOrDefault();
            this.ViewData["Products"] = new SelectList(lastVersions, "Id", "Name");
        }
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
       [OutputCache(Duration=600)]
         protected PurchaseOrder GetPO(int id)
        {
            PurchaseOrder po = null;
            po = db.PurchaseOrders.OrderByDescending(t => t.Version).FirstOrDefault(t => t.ID == id);
            return po;
        }

        protected void CreateCustomersList(SalesOrder workSO)
        {
            var customers = db.Customers;
            List<object> newList = new List<object>();
            foreach (var customer in customers)
                newList.Add(new
                {
                    Id = customer.ID,
                    Name = customer.FirstName + " " + customer.LastName
                });
            this.ViewData["CustomerID"] = new SelectList(newList, "Id", "Name", workSO.CustomerID);
        }
        protected void CreateProductsList(SalesOrderItem workSOitem)
        {
            this.ViewData["ProductID"] = new SelectList(db.Products, "Id", "Name", workSOitem.ProductID);
        }
        protected void CreateCustomersList(Sales workSales)
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
        protected void CreateProductsList(SalesItem workSalesItem)
        {
            this.ViewData["ProductID"] = new SelectList(db.Products, "Id", "Name", workSalesItem.ProductID);
        }
    }
}