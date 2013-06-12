using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace b.Models
{
    public class StoreTransferItem
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Qty { get; set; }
        public Decimal Rate { get; set; }
        public Decimal Amount { get; set; }
    }
}