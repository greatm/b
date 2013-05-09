using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace b.ViewModels
{
    public class PurchaseItem
    {
        [Timestamp]
        public Byte[] Timestamp { get; set; }
        public int ProductID { get; set; }
        public int Qty { get; set; }
        public Decimal Rate { get; set; }
    }
}
