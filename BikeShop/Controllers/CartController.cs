using BikeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikeShop.Controllers
{
    public class CartController : Controller
    {
        //BDConext Object
        private ApplicationDbContext _context;


        public static List<Product> addedToCart = new List<Product>();



        //Create the Constructor
        public CartController()
        {
            _context = new ApplicationDbContext();

        }

        // GET: Cart
        public ActionResult Index()
        {
            var list = addedToCart;



            return View(list);
        }

        public ActionResult AddTo(int id)
        {
            Product selectedProduct = _context.Products.Find(id);

            addedToCart.Add(selectedProduct);

            return RedirectToAction("Index", "Products");
        }

        public ActionResult Remove(int id)
        {
            Product selectedProduct = addedToCart.First(c => c.ProductID == id);

            addedToCart.Remove(selectedProduct);

            return RedirectToAction("Index", "Cart");
        }

        public ActionResult Flush()
        {
            addedToCart = new List<Product>();

            return RedirectToAction("Index", "Products");
        }
    }
}