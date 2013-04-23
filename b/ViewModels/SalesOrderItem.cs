using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace b.ViewModels
{
    public class SalesOrderItem
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int Qty { get; set; }
        public Decimal Rate { get; set; }
    }
}