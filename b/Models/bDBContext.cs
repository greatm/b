using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using b.ViewModels;

namespace b.Models
{
    public class bDBContext : DbContext
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<whatsnew> whatsnews { get; set; }

        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<Sales> Sales { get; set; }

    }
}
//context.whatsnews.AddOrUpdate(
//               p => p.WorkTime,

//               new whatsnew { WorkTime = new DateTime(2013, 5, 9, 10, 30, 0), Work = "add master store" },
//               new whatsnew { WorkTime = new DateTime(2013, 5, 8, 10, 30, 0), Work = "add IsPostedFromThisSite Attribute" },
//               new whatsnew { WorkTime = new DateTime(2013, 5, 7, 10, 30, 0), Work = "install package AntiXSS" },
//               new whatsnew { WorkTime = new DateTime(2013, 5, 6, 10, 30, 0), Work = "product add color and pic" },
//               new whatsnew { WorkTime = new DateTime(2013, 5, 4, 10, 30, 0), Work = "add this update time in site" },
//               new whatsnew { WorkTime = new DateTime(2013, 5, 3, 10, 30, 0), Work = "use jquery in site" },
//               new whatsnew { WorkTime = new DateTime(2013, 5, 2, 10, 30, 0), Work = "add master customer" },
//               new whatsnew { WorkTime = new DateTime(2013, 4, 26, 10, 30, 0), Work = "add master product" },
//               new whatsnew { WorkTime = new DateTime(2013, 4, 26, 10, 20, 0), Work = "add master vendor" },
//               new whatsnew { WorkTime = new DateTime(2013, 4, 26, 10, 10, 0), Work = "add logo" }
//               );