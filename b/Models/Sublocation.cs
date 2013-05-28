using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace b.Models
{
    public class Sublocation : VersionTable
    {
        public virtual Store Store { get; set; }
        public virtual int StoreID { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}