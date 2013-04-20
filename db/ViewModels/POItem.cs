using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace db.ViewModels
{
    public class POItem
    {
        public int ProductID { get; set; }
        public int Qty { get; set; }
        public Decimal Rate { get; set; }
    }
}