using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using b.ViewModels;
using db.Models;

namespace b.Models
{
    public class bDBContext1 : DbContext
    {
        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Product> Products { get; set; }

        //public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
    }
}