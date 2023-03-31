using AspNetCoreMvc.Logging;
using AspNetCoreMvc.Models;
using AspNetCoreMvc.Repositories.Abstract;
using AspNetCoreMvc.Repositories.Concrete;
using AspNetCoreMvc.Utilities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;


namespace AspNetCoreMvc.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IValidator<Product> _validator;

        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository, IValidator<Product> validator)
        {
            _logger = logger;
            _productRepository = productRepository;
            _validator = validator;
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
            var validationResult = _validator.Validate(product);

            if (validationResult.IsValid)
            {
                _productRepository.Add(product);
                TempData["notification"] = Notification.BasicNotification("Məhsul uğurla əlavə edildi", NotificationType.Success);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ViewData["ValidationResults"] = item.ErrorMessage;
                }

                var values = _productRepository.SelectCategoryItems();
                ViewBag.v1 = values;
                return View();
            }
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

            var validationResult = _validator.Validate(product);

            if (validationResult.IsValid)
            {
                _productRepository.Update(updatedProduct);
                TempData["notification"] = Notification.BasicNotification("Məhsul uğurla redaktə edildi", NotificationType.Success);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ViewData["ValidationResults"] = item.ErrorMessage;
                }

                var values = _productRepository.SelectCategoryItems();
                ViewBag.v1 = values;
                return View();
            }
        }

        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            Product product = _productRepository.GetProductById(id);
            return PartialView("_DeleteProductPartial", product);
        }

        [HttpPost]
        public IActionResult DeleteProduct(Product product)
        {
            try
            {
                _productRepository.Delete(product);
                TempData["notification"] = Notification.BasicNotification("Məhsul uğurla silindi", NotificationType.Success);
                FileLogger.Log("DeleteProduct", "Məhsul silindi. ProductId = " + product.ProductId);
            }
            catch (Exception ex)
            {
                TempData["notification"] = Notification.BasicNotification("Xəta baş verdi: " + ex.Message, NotificationType.Error);
                FileLogger.Log("DeleteProduct", "Xəta baş verdi: " + ex.Message);
            }
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}