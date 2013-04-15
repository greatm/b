using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using b.Models;

namespace b.ViewModels
{
    public class PurchaseOrder
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public Vendor Vendor { get; set; }
        public string Remarks { get; set; }
    }
}