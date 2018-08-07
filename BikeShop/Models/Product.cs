using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeShop.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public DateTime DateCreation { get; set; }

        public Category Category { get; set; }
        public int CategoryID { get; set; }

    }
}