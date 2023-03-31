using AspNetCoreMvc.Models;
using AspNetCoreMvc.Repositories.Abstract;
using AspNetCoreMvc.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;


namespace AspNetCoreMvc.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;

        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var values = _productRepository.GetProductDetails();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            var values = _productRepository.SelectCategoryItems();
            ViewBag.v1 = values;
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _productRepository.Add(product);
            TempData["notification"] = Notification.BasicNotification("Məhsul uğurla əlavə edildi", NotificationType.Success);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var product = _productRepository.GetProductById(id);
            var values = _productRepository.SelectCategoryItems();
            ViewBag.v1 = values;
            return View("UpdateProduct", product);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product) {
            var updatedProduct = _productRepository.GetProductById(product.ProductId);
            updatedProduct.ProductName = product.ProductName;
            updatedProduct.CategoryId = product.CategoryId;
            updatedProduct.UnitsInStock = product.UnitsInStock;
            updatedProduct.UnitPrice = product.UnitPrice;   
            _productRepository.Update(updatedProduct);
            TempData["notification"] = Notification.BasicNotification("Məhsul uğurla redaktə edildi", NotificationType.Success);
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}