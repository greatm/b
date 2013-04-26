using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace b.Models
{
    public class PackingList
    {
        public string Item { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int CaseFrom { get; set; }
        public int CaseTo { get; set; }
        public int QtyPerCase { get; set; }
        public int TotalQty { get; set; }
    }
}