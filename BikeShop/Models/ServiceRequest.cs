using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeShop.Models
{
    public class ServiceRequest
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Appointment Date")]
        public DateTime? AppointmentDate { get; set; }

        public Service Service { get; set; }
        public int ServiceId { get; set; }

    }
}