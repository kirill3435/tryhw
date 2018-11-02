using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Data;

namespace Shop.Controllers
{
    public class ProductsController : Controller
    {

        private readonly ShopContext _db;

        public ProductsController(ShopContext context)
        {
            context.Products.Add(new Product("Ананас", 20));
            context.SaveChanges();
            _db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {

            IEnumerable<Product> products = _db.Products;
            ViewBag.Products = products;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}