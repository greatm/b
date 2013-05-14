using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace b.Models
{
    public class Sublocation
    {
        public int ID { get; set; }
        public Store Store { get; set; }
        public int StoreID { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
    }
}