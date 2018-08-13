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
        [Display(Name = "Service Description")]
        public string ServiceDetail { get; set; }

        public ServiceType ServiceType { get; set; }

        [Display(Name = "ServiceType")]
        public int ServiceTypeID { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "The picture for the service is required"), FileExtensions("jpg,jpeg,png,gif", ErrorMessage = "Please upload image files")]
        public HttpPostedFileBase File { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

    }
}