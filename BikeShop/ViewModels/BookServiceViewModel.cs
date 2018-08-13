using BikeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeShop.ViewModels
{
    public class BookServiceViewModel
    {
        public ServiceRequest ServiceRequest { get; set; }
        public Service Service { get; set; }
    }
}