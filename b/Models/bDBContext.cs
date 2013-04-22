using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using db.Models;

//namespace b.Models
//{
//public class bDBContext1 : DbContext
//{
//    public DbSet<UserProfile> UserProfiles { get; set; }

//    public DbSet<Vendor> Vendors { get; set; }
//    public DbSet<Product> Products { get; set; }

//    //public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
//}
//}

namespace b.Models
{
    public class db_bDBContext : bDBContext
    {
        //public DbSet<dummy> dummys { get; set; }
    }
    //public class dummy
    //{
    //    public string Dummy { get; set; }
    //}
}