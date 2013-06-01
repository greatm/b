using b.ViewModels;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace b.Models
{
    public class bDBContext : DbContext
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<whatsnew> whatsnews { get; set; }

        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sublocation> Sublocations { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<Sales> Sales { get; set; }
    }
    public class VersionTable
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int ID { get; set; }

        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int Version { get; set; }

        [DataType(DataType.Date)]
        public virtual DateTime EntryDate { get; set; }

        public virtual string Remarks { get; set; }
    }
    public static class Updater
    {
        public static void AddorUpdate(bDBContext context)
        {
            context.whatsnews.AddOrUpdate(
                p => p.WorkTime,

                //new whatsnew { WorkTime = new DateTime(2013, 6, 01, 14, 00, 0), Work = "A B add version in sales" },
                new whatsnew { WorkTime = new DateTime(2013, 6, 01, 14, 00, 0), Work = "A B add version in sales" },
                new whatsnew { WorkTime = new DateTime(2013, 6, 01, 13, 00, 0), Work = "A B add version in purchase" },
                new whatsnew { WorkTime = new DateTime(2013, 6, 01, 12, 00, 0), Work = "A B install package miniprofiler" },
                new whatsnew { WorkTime = new DateTime(2013, 6, 01, 11, 00, 0), Work = "A B po – create – server error" },
                new whatsnew { WorkTime = new DateTime(2013, 5, 31, 16, 00, 0), Work = "A B version delete – all versions" },
                new whatsnew { WorkTime = new DateTime(2013, 5, 31, 15, 00, 0), Work = "A B master store edit – save gives error – server error" },
                new whatsnew { WorkTime = new DateTime(2013, 5, 31, 14, 00, 0), Work = "A B master product edit – save gives error – server error" },
                new whatsnew { WorkTime = new DateTime(2013, 5, 31, 13, 00, 0), Work = "A B master vendor edit – save gives error – server error" },
                new whatsnew { WorkTime = new DateTime(2013, 5, 31, 12, 00, 0), Work = "A B po items add button working" },
                new whatsnew { WorkTime = new DateTime(2013, 5, 30, 12, 00, 0), Work = "A B po items drag working" },
                new whatsnew { WorkTime = new DateTime(2013, 5, 29, 17, 00, 0), Work = "A B master vendor – save error" },
                new whatsnew { WorkTime = new DateTime(2013, 5, 29, 16, 00, 0), Work = "A B add version in masters" },
                new whatsnew { WorkTime = new DateTime(2013, 5, 29, 15, 00, 0), Work = "A B add version table" },
                new whatsnew { WorkTime = new DateTime(2013, 5, 29, 14, 00, 0), Work = "A B master product create – save gives server error " },
                new whatsnew { WorkTime = new DateTime(2013, 5, 29, 13, 00, 0), Work = "A B po edit load from database" },
                new whatsnew { WorkTime = new DateTime(2013, 5, 29, 12, 00, 0), Work = "A B site colors – same as p" },
                new whatsnew { WorkTime = new DateTime(2013, 5, 29, 10, 30, 0), Work = "A B menu – left accordion" },
                new whatsnew { WorkTime = new DateTime(2013, 5, 27, 11, 30, 0), Work = "One screen multiple person – versions difirent - vendor" },
                new whatsnew { WorkTime = new DateTime(2013, 5, 27, 10, 30, 0), Work = "mvc 4 key multiple" },
                new whatsnew { WorkTime = new DateTime(2013, 5, 14, 10, 30, 0), Work = "po auto fill – all quantities" },
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
