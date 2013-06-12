using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using b.Models;

namespace b.Models
{
    public class SalesOrder : VersionTable
    {
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public int CustomerID { get; set; }

        public IList<SalesOrderItem> SalesOrderItems { get; set; }
        public decimal TotalAmount { get; set; }
    }
}