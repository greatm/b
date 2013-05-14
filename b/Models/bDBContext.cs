using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using b.ViewModels;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

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

        public DbSet<Sublocation> Sublocations { get; set; }

    }

    public static class Updater
    {
        public static void AddorUpdate(bDBContext context)
        {
            context.whatsnews.AddOrUpdate(
                p => p.WorkTime,


                //new whatsnew { WorkTime = new DateTime(2013, 5, 14, 10, 30, 0), Work = "add master store" },
                new whatsnew { WorkTime = new DateTime(2013, 5, 13, 10, 30, 0), Work = "add purchase po" },
                new whatsnew { WorkTime = new DateTime(2013, 5, 11, 10, 30, 0), Work = "add status message" },
                new whatsnew { WorkTime = new DateTime(2013, 5, 10, 10, 30, 0), Work = "sale create – add box number" },
                new whatsnew { WorkTime = new DateTime(2013, 5, 09, 10, 30, 0), Work = "add master store" },
                new whatsnew { WorkTime = new DateTime(2013, 5, 08, 10, 30, 0), Work = "add IsPostedFromThisSite Attribute" },
                new whatsnew { WorkTime = new DateTime(2013, 5, 07, 10, 30, 0), Work = "install package AntiXSS" },
                new whatsnew { WorkTime = new DateTime(2013, 5, 06, 10, 30, 0), Work = "product add color and pic" },
                new whatsnew { WorkTime = new DateTime(2013, 5, 04, 10, 30, 0), Work = "add this update time in site" },
                new whatsnew { WorkTime = new DateTime(2013, 5, 03, 10, 30, 0), Work = "use jquery in site" },
                new whatsnew { WorkTime = new DateTime(2013, 5, 02, 10, 30, 0), Work = "add master customer" },
                new whatsnew { WorkTime = new DateTime(2013, 4, 26, 10, 30, 0), Work = "add master product" },
                new whatsnew { WorkTime = new DateTime(2013, 4, 26, 10, 20, 0), Work = "add master vendor" },
                new whatsnew { WorkTime = new DateTime(2013, 4, 26, 10, 10, 0), Work = "add logo" }
                );
        }
    }
}
