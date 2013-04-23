using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace b.ViewModels
{
    public class SalesOrder
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int CustomerID { get; set; }
        public string Remarks { get; set; }
        public IEnumerable<SalesOrderItem> PurchaseItems { get; set; }
    }
}