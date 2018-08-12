using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BikeShop.Models;
using BikeShop.ViewModels;
using System.IO;

namespace BikeShop.Controllers
{
    public class ServicesController : Controller
    {

        //BDConext Object
        private ApplicationDbContext _context;


        public ServicesController()
        {
            _context = new ApplicationDbContext();

        }


        // GET: Services
        public ActionResult Index(string searchString)
        {
            var services = _context.Services.Include(p => p.ServiceType);

            if (!string.IsNullOrEmpty(searchString))
                services = services.Where(p => p.ServiceName.Contains(searchString));

            return View(services.ToList());

        }



        //Add a New Product
        public ActionResult New()
        {
            var viewModel = new ServiceFormViewModel
            {
                Service = new Service(),
                ServiceTypes = _context.ServiceTypes.ToList(),
                Option = "New"
            };
            return View("ServiceForm", viewModel);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Service service, HttpPostedFileBase ImageFile)
        {
            using (var ms = new MemoryStream())
            {
                ImageFile.InputStream.CopyTo(ms);
                service.Image = ms.ToArray();
            }

            //Check if the form is valid
            if (!ModelState.IsValid)
            {
                //Return the same form back to the user
                var viewModel = new ServiceFormViewModel
                {
                    Service = service,
                    ServiceTypes = _context.ServiceTypes.ToList(),
                    Option = "New"
                };
                return View("ServiceForm", viewModel);
            }
            //new service
            if (service.ServiceID == 0)
            {
                _context.Services.Add(service);
            }
            else
            {
                var serviceInDB = _context.Services.Single(p => p.ServiceID == service.ServiceID);

                //Manual update
                serviceInDB.ServiceName = service.ServiceName;
                serviceInDB.ServiceDetail = service.ServiceDetail;
                serviceInDB.Price = service.Price;
                serviceInDB.ServiceTypeID = service.ServiceTypeID;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Services");
        }




        //Details Action
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            var service = _context.Services.Include(c => c.ServiceType).SingleOrDefault(p => p.ServiceID == id);

            if (service == null)
            {
                return HttpNotFound();
            }

            return View(service);
        }



        //Edit services details
        public ActionResult Edit(int id)
        {
            var serviceInDB = _context.Services.SingleOrDefault(p => p.ServiceID == id);

            if (serviceInDB == null)
                return HttpNotFound();

            var viewModel = new ServiceFormViewModel()
            {
                Service = serviceInDB,
                ServiceTypes = _context.ServiceTypes.ToList(),
                Option = "Edit"
            };

            return View("ServiceForm", viewModel);
        }




        //This action will display a confirm message to the user to confirm the delete operation
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return HttpNotFound();

            var service = _context.Services.Include(c => c.ServiceType).SingleOrDefault(p => p.ServiceID == id);

            if (service == null)
                return HttpNotFound();

            return View(service);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var service = _context.Services.Find(id);
            _context.Services.Remove(service);
            _context.SaveChanges();

            return RedirectToAction("Index", "Services");
        }



    }
}