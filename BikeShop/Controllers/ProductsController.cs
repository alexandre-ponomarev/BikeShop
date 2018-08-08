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
    public class ProductsController : Controller
    {
        //BDConext Object
        private ApplicationDbContext _context;

        //Create the Constructor
        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Products
        public ActionResult Index(string searchString)
        {
            var products = _context.Products.Include(p => p.Category);

            if (!string.IsNullOrEmpty(searchString))
                products = products.Where(p => p.ProductName.Contains(searchString));

            return View(products.ToList());

        }

        //Add a New Product
        public ActionResult New()
        {
            var viewModel = new ProductFormViewModel
            {
                Product = new Product(),
                Categories = _context.Categories.ToList()
            };
            return View("ProductForm", viewModel);
        }



        //Post action to save data from my form (2)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Product product, HttpPostedFileBase ImageFile)
        {
            using (var ms = new MemoryStream())
            {
                ImageFile.InputStream.CopyTo(ms);
                product.Image = ms.ToArray();
            }

            //Check if the form is valid
            if (!ModelState.IsValid)
            {
                //Return the same form back to the user
                var viewModel = new ProductFormViewModel
                {
                    Product = product,
                    Categories = _context.Categories.ToList()
                };
                return View("ProductForm", viewModel);
            }
            //new product
            if (product.ProductID == 0)
            {
                _context.Products.Add(product);
            }
            else
            {
                var productInDB = _context.Products.Single(p => p.ProductID == product.ProductID);

                //Manual update
                productInDB.ProductName = product.ProductName;
                productInDB.Stock = product.Stock;
                productInDB.Price = product.Price;
                productInDB.DateCreation = product.DateCreation;
                productInDB.CategoryID = product.CategoryID;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Products");
        }



        //Details Action
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            var product = _context.Products.Include(c => c.Category).SingleOrDefault(p => p.ProductID == id);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }


        //Edit product details
        public ActionResult Edit(int id)
        {
            var productInDB = _context.Products.SingleOrDefault(p => p.ProductID == id);

            if (productInDB == null)
                return HttpNotFound();

            var viewModel = new ProductFormViewModel()
            {
                Product = productInDB,
                Categories = _context.Categories.ToList()
            };

            return View("ProductForm", viewModel);
        }


        //This action will display a confirm message to the user to confirm the delete operation
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return HttpNotFound();

            var product = _context.Products.Include(c => c.Category).SingleOrDefault(p => p.ProductID == id);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index", "Products");
        }


    }
}