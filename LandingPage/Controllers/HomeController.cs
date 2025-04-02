using LandingPage.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LandingPage.Controllers
{
    public class HomeController : Controller
    {
        Context context = new Context();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Product> Products = context.products.ToList();
            return View(Products);
            
        }
        public IActionResult ArDetails(int id) {

            Product Pro = context.products.FirstOrDefault(d => d.Id == id);
            return View("ArDetails", Pro);
        
        }
        public IActionResult EnDetail(int id)
        {

            Product Pro = context.products.FirstOrDefault(d => d.Id == id);
            return View("EnDetail", Pro);

        }

        public IActionResult en()
        {
            List<Product> Products = context.products.ToList();
            return View("en", Products);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
