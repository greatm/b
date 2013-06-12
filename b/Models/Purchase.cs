using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using b.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace b.Models
{
    public class Purchase : VersionTable
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public PurchaseOrder PO { get; set; }
        public int POID { get; set; }
        //public int VendorID { get; set; }
        public string VendorInvoice { get; set; }
        public IEnumerable<PurchaseItem> PurchaseItems { get; set; }

        public IEnumerable<Vendor> Vendors { get; set; }
    }

    public class PagedPurchaseModel
    {
        public int TotalRows { get; set; }
        public IEnumerable<PurchaseItem> PurchaseItems { get; set; }
        public int PageSize { get; set; }
    }
}
