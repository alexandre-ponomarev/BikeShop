using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BikeShop.Models;

namespace BikeShop.ViewModels
{
    public class ServiceFormViewModel
    {
        public Service Service { get; set; }
        public IEnumerable<ServiceType> ServiceTypes { get; set; }
        public string Option { get; set; }
    }
}