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
        [Authorize(Roles = RoleNames.Admin)]
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
        [Authorize(Roles = RoleNames.Admin)]
        public ActionResult Save(Service service)
        {
            

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

            using (var ms = new MemoryStream())
            {
                service.File.InputStream.CopyTo(ms);
                service.Image = ms.ToArray();
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
                serviceInDB.ServiceTypeID = service.ServiceTypeID;
                serviceInDB.Image = service.Image;
                serviceInDB.File = service.File;
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
        [Authorize(Roles = RoleNames.Admin)]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return HttpNotFound();

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
        [Authorize(Roles = RoleNames.Admin)]
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
        [Authorize(Roles = RoleNames.Admin)]
        public ActionResult Delete(int id)
        {
            var service = _context.Services.Find(id);
            _context.Services.Remove(service);
            _context.SaveChanges();

            return RedirectToAction("Index", "Services");
        }

        public ActionResult BookService(int? id)
        {
            if (!id.HasValue)
                return HttpNotFound();

            var viewModel = new BookServiceViewModel()
            {
                Service = _context.Services.SingleOrDefault(s => s.ServiceID == id),
                ServiceRequest = new ServiceRequest {
                    ServiceId = (int)id
                }
            };

            if (viewModel.Service == null)
                return HttpNotFound();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveRequest(ServiceRequest serviceRequest)
        {

            var viewModel = new BookServiceViewModel()
            {
                Service = _context.Services.First(s => s.ServiceID == serviceRequest.ServiceId),
                ServiceRequest = serviceRequest
            };

            //Check if the form is valid
            if (!ModelState.IsValid)
            {
                return View("BookService", viewModel);
            }

            //new service
            if (serviceRequest.Id == 0)
            {
                _context.ServiceRequests.Add(serviceRequest);
            }


            _context.SaveChanges();

            return View("Confirmation", viewModel);
        }
    }
}