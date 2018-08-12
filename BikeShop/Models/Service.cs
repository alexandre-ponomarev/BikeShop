using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeShop.Models
{
    public class Service
    {
        public int ServiceID { get; set; }

        [Required(ErrorMessage = "Please enter the service's name")]
        [StringLength(100)]
        [Display(Name = "Service Name")]
        public string ServiceName { get; set; }

        [Required(ErrorMessage = "Please enter the service's detail")]
        [StringLength(500)]
        [Display(Name = "Service detail")]
        public string ServiceDetail { get; set; }

        [Required]
        [Display(Name = "Price of Service")]
        public float Price { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        public ServiceType ServiceType { get; set; }

        [Display(Name = "ServiceType")]
        public int ServiceTypeID { get; set; }

    }
}