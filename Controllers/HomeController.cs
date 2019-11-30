using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using web.Models;
using web.Repository;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        //private IGenress genRepo;
        private readonly WebContext _context;
        public HomeController(WebContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            var list_genres1 = from e in _context.Genresses
                              where e.gen_cate == 1
                              select e;
            var list_genres2 = from e in _context.Genresses
                               where e.gen_cate == 2
                               select e;
            var list_genres3 = from e in _context.Genresses
                               where e.gen_cate == 3
                               select e;
            var list_genres4 = from e in _context.Genresses
                               where e.gen_cate == 4
                               select e;
            ViewData["theloai"] = list_genres1;
            ViewData["quocgia"] = list_genres2;
            ViewData["phimle"] = list_genres3;
            ViewData["phimbo"] = list_genres4; 
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
        //[HttpPost]
        //public IActionResult Register(Student student)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Repository.AddStudent(student);
        //        return View("Thanks", student);
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
        //public IActionResult StudentList()
        //{
        //    return View(Repository.GetStudents());
        //}
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
