using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using b.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace b.ViewModels
{
    public class Sales : VersionTable
    {
        //public int ID { get; set; }
        //[Timestamp]
        //public Byte[] Timestamp { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public int CustomerID { get; set; }

        [Display(Name = "Sale Order Reference")]
        public int SOID { get; set; }

        [Display(Name = "Invoice Number")]
        public string Invoice { get; set; }
        //public string Remarks { get; set; }
        public IList<SalesItem> SalesItems { get; set; }
        public PackingList PackingList { get; set; }
        public string BoxNumber { get; set; }
    }
}