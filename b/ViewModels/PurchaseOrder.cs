using b.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace b.ViewModels
{
    public class PurchaseOrder : VersionTable
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public Vendor Vendor { get; set; }
        public int VendorID { get; set; }
        public int StoreID { get; set; }
        public IList<POItem> POItems { get; set; }
    }
}