using AspNetCoreMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc.Controllers
{
    public class StatisticController : Controller
    {
        public IActionResult Index()
        {
            using (Context context = new Context())
            {
                var countOfProducts = context.Products.Count();
                ViewBag.CountOfProducts = countOfProducts;

                var countOfCategories = context.Categories.Count();
                ViewBag.CountOfCategories = countOfCategories;

                var countOfOrders = context.Orders.Count();
                ViewBag.CountOfOrders = countOfOrders;


                var countOfCustomers = context.Customers.Count();
                ViewBag.CountOfCustomers = countOfCustomers;

                return View();
            }
        }
    }
}
