using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using b.Models;

namespace b.ViewModels
{
    public class Sales
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int SOID { get; set; }
        public int CustomerID { get; set; }
        public string Invoice { get; set; }
        public string Remarks { get; set; }
        public IList<SalesItem> SalesItems { get; set; }
        public PackingList PackingList { get; set; }
    }
}