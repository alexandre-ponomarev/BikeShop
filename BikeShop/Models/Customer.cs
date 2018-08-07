using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeShop.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [Required]
        [StringLength(80)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(80)]
        public string Lasttname { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(30)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(10)]
        public string PostalCode { get; set; }

    }
}