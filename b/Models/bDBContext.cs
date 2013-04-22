using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using b.ViewModels ;

namespace b.Models
{
    public class bDBContext : DbContext
    {
        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
    }
}

//namespace b.Models
//{
//    public class db_bDBContext : bDBContext
//    {
//    }
//}