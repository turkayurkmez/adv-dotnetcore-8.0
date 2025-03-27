using System.Diagnostics;
using customTagBuilder.Models;
using Microsoft.AspNetCore.Mvc;

namespace customTagBuilder.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int page=1)
        {
            var products = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };

            var pageSize = 4;
            var count = products.Length;

            var totalPages = (int)Math.Ceiling(count / (double)pageSize);

            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                PageSize = pageSize,
                TotalItems = count
            };

            //ViewBag.TotalPages = totalPages;

            products = products.Skip((page - 1) * pageSize).Take(pageSize).ToArray();

            var model = new HomeIndexViewModel
            {
                Products = products,
                PagingInfo = pagingInfo
            };


            return View(model);
        }

        public IActionResult Privacy(int page)
        {
            var vendors = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J","K","L", "I", "J", "K", "L", "I", "J", "K", "L" };
            var pageModel = new PagingInfo
            {
                CurrentPage = page,
                PageSize = 4,
                TotalItems = vendors.Length
            };

            vendors = vendors.Skip((page - 1) * pageModel.PageSize).Take(pageModel.PageSize).ToArray();
            var model = new HomePrivacyViewModel()
            {
                Vendor = vendors,
                PagingInfo= pageModel

            };

            return View(model);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
