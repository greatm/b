using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace b.ViewModels
{
    public class SalesOrderItem
    {
        public int ID { get; set; }
        [Timestamp]
        public Byte[] Timestamp { get; set; }
        public int ProductID { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
    }
}