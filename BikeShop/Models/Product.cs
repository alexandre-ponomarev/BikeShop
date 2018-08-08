﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BikeShop.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Please enter the product's name")]
        [StringLength(100)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Stock")]
        public int Stock { get; set; }

        [Required]
        [Display(Name = "Price of Product")]
        public float Price { get; set; }

        [Display(Name = "Date of Creation")]
        public DateTime? DateCreation { get; set; }

        public Category Category { get; set; }

        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
    }
}