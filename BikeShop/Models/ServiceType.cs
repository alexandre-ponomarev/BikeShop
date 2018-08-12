using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeShop.Models
{
    public class ServiceType
    {
        public int ServiceTypeID { get; set; }

        [Required]
        [StringLength(100)]
        public string ServiceTypeName { get; set; }
    }
}