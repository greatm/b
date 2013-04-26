using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace b.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        [Display(Name = "Unit of Measurement")]
        public string UoM { get; set; }

        [Display(Name = "Re Order Level")]
        public int RoL { get; set; }

        [Display(Name = "Re Order Quantity" )]
        public int RoQ { get; set; }
        public string Remarks { get; set; }
    }
}