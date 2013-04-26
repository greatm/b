using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace b.Models
{
    public class whatsnew
    {
        [Key]
        public DateTime WorkTime { get; set; }
        public string Work { get; set; }
    }
}