using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace b.ViewModels
{
    public class CustomerSummary
    {
        public string Name { get; set; }
        public string Active { get; set; }
        public string ServiceLevel { get; set; }
        public string OrderCount { get; set; }
        public string MostRecentOrderDate { get; set; }
    }
}