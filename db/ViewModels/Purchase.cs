using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using db.Models;

namespace db.ViewModels
{
    public class Purchase
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int POID { get; set; }
        public int VendorID { get; set; }
        public IEnumerable<Vendor> Vendors { get; set; }
        public string Remarks { get; set; }
        public IEnumerable<PurchaseItem> PurchaseItems { get; set; }
    }
}
