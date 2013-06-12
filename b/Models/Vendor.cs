using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace b.Models
{
    public class Vendor : VersionTable
    {
        public string Name { get; set; }
        public string Person { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string eMail { get; set; }
        public string WebSite { get; set; }
    }
}