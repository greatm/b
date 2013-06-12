using b.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace b.Models
{
    public class POItem
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Qty { get; set; }
        public Decimal Rate { get; set; }
        public Decimal Amount { get; set; }
    }
}