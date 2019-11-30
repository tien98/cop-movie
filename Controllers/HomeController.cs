using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using web.Models;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult News()
        {
            
            return View();
        }
        public IActionResult About()
        {  
            return View();
        }
        public IActionResult Contact()
        {
          
            return View();
        }
        public IActionResult Details()
        {
           
            return View();
        }
        public IActionResult WatchMovie()
        {
            
            return View();
        }
        public ViewResult Index2()
        {
            int Hour = DateTime.Now.Hour;
            ViewBag.Name = "tien";
            ViewBag.Greeting = Hour > 12 ? "Chao buoi sang" : "Chao buoi chieu";
            return View("myView");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Student student)
        {
            if (ModelState.IsValid)
            {
                Repository.AddStudent(student);
                return View("Thanks", student);
            }
            else
            {
                return View();
            }
        }
        public IActionResult StudentList()
        {
            return View(Repository.GetStudents());
        }
        public IActionResult ProductList()
        {
            List<String> lstResult = new List<string>();
            Product[] products = Product.GetProducts();
            foreach(Product p in products)
            {
                string name = p?.Name;
                decimal? price = p?.Price;
                string related = p?.Related?.Name;
                lstResult.Add(string.Format("Name: {0}, Price: {1}, Related: {2}", name, price, related));
            }
            return View(lstResult);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
