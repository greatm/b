﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace b.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public bool Active { get; set; }
        public ServiceLevel ServiceLevel { get; set; }
    }
    public enum ServiceLevel
    {
        Standard,
        Premier
    }
}