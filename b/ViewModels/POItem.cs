using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using b.Models;

namespace b.ViewModels
{
    public class POItem
    {
        public int ID { get; set; }
        public int POID { get; set; }
        public Product Item { get; set; }
        public int Qty { get; set; }
        public Decimal Rate { get; set; }
    }
}