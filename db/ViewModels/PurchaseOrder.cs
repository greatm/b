﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using db.Models;

namespace db.ViewModels
{
    public class PurchaseOrder
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int VendorID { get; set; }
        public IEnumerable<Vendor> Vendors { get; set; }
        public string Remarks { get; set; }
        public IEnumerable<POItem> POItems { get; set; }
    }
}