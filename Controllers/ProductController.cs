using Microsoft.AspNetCore.Mvc;
using ProductMVC.Models;

namespace ProductMVC.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>();

        public IActionResult Index()
        {
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                products.Add(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }

        public IActionResult Edit(int id)
        {
            var product = products.Find(p => p.ProductId == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = products.Find(p => p.ProductId == product.ProductId);
                existingProduct.ProductName = product.ProductName;
                existingProduct.ProductDescription = product.ProductDescription;

                return RedirectToAction("Index");
            }

            return View(product);
        }
    }
}