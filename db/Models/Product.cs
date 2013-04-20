using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace db.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string UoM { get; set; }
        public string RoL { get; set; }
        public string RoQ { get; set; }
        public string Remarks { get; set; }
    }
}