using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b.ViewModels
{
    public class PurchaseItem
    {
        public int ProductID { get; set; }
        public int Qty { get; set; }
        public Decimal Rate { get; set; }
    }
}
