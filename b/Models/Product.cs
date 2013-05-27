using b.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace b.Models
{
    public class Product : VersionTable
    {
        //public int ID { get; set; }
        //[Timestamp]
        //public Byte[] Timestamp { get; set; }

        [Required]
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        [Display(Name = "Unit of Measurement", Prompt = "Enter here")]
        public string UoM { get; set; }

        [Display(Name = "Re Order Level")]
        public int RoL { get; set; }

        [Display(Name = "Re Order Quantity")]
        public int RoQ { get; set; }
        public decimal LastPurchaseRate { get; set; }
        public string Color { get; set; }
        public byte[] Image { get; set; }

        //[MaxWords(10)]
        //[Display(Prompt = "any thing about this product")]
        //public string Remarks { get; set; }

        public Product()
        {
            RoL = 10;
            RoQ = 20;
        }
    }
}