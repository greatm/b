using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using b.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace b.ViewModels
{
    public class PurchaseOrder
    {
        public int ID { get; set; }
        [Timestamp]
        public Byte[] Timestamp { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int VendorID { get; set; }

        public string Remarks { get; set; }
        public IList<POItem> POItems { get; set; }

        public IEnumerable<Vendor> Vendors { get; set; }
    }
}