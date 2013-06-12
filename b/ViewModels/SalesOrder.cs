﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using b.Models;

namespace b.ViewModels
{
    public class SalesOrder : VersionTable
    {
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public int CustomerID { get; set; }

        //[StringLength(5, ErrorMessage = "always keep remarks short and simple")]
        //public string Remarks { get; set; }
        public IList<SalesOrderItem> SalesOrderItems { get; set; }
        public decimal TotalAmount { get; set; }
    }
}