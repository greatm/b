using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using b.Models;

namespace b.ViewModels
{
    public class POwithVendor
    {
        public PurchaseOrder PO { get; set; }
        public Vendor Vendor { get; set; }
    }
}