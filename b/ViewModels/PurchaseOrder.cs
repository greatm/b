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
        public virtual Vendor Vendor { get; set; }
        public virtual int VendorID { get; set; }
        public virtual int StoreID { get; set; }
        public virtual IList<POItem> POItems { get; set; }
    }
}