using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web.Models;
using web.Services;

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
        public IActionResult Index(int page = 1)
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
            //var lstMovie = from e in _context.Movies
            //                   select e;
            ViewData["theloai"] = list_genres1;
            ViewData["quocgia"] = list_genres2;
            ViewData["phimle"] = list_genres3;
            ViewData["phimbo"] = list_genres4;
            //ViewData["lastest"] = lstMovie;

            // static function can call directly here
            string x = VietnameseConverter.Class1.RemoveVietnameseSigns("Đây là bát test của m!!");
            var dataPage = _context.Movies.GetPaged(page, 18);
            ViewData["lastest"] = dataPage.Result;
            return View(dataPage);
        }


        public IActionResult News()
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
            var lstMovie = from e in _context.Movies
                           select e;
            ViewData["theloai"] = list_genres1;
            ViewData["quocgia"] = list_genres2;
            ViewData["phimle"] = list_genres3;
            ViewData["phimbo"] = list_genres4;
            ViewData["lastest"] = lstMovie;
            return View();
        }
        public IActionResult About()
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
            var lstMovie = from e in _context.Movies
                           select e;
            ViewData["theloai"] = list_genres1;
            ViewData["quocgia"] = list_genres2;
            ViewData["phimle"] = list_genres3;
            ViewData["phimbo"] = list_genres4;
            ViewData["lastest"] = lstMovie;
            return View();
        }
        public IActionResult Contact()
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
            var lstMovie = from e in _context.Movies
                           select e;
            ViewData["theloai"] = list_genres1;
            ViewData["quocgia"] = list_genres2;
            ViewData["phimle"] = list_genres3;
            ViewData["phimbo"] = list_genres4;
            ViewData["lastest"] = lstMovie;
            return View();
        }
        [Route("{controller}/{action}/{id?}")]
        public IActionResult Details(int id)
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
            var lstMovie = from e in _context.Movies
                           select e;

            ViewData["theloai"] = list_genres1;
            ViewData["quocgia"] = list_genres2;
            ViewData["phimle"] = list_genres3;
            ViewData["phimbo"] = list_genres4;
            ViewData["lastest"] = lstMovie;
            var detail = from e in _context.Movies
                         where e.mov_id == id
                         select e;
            ViewData["detail"] = detail;
            return View();
        }

        public async Task<IActionResult> Search(string? searchString)
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
            //var lstMovie = from e in _context.Movies
            //                   select e;
            ViewData["theloai"] = list_genres1;
            ViewData["quocgia"] = list_genres2;
            ViewData["phimle"] = list_genres3;
            ViewData["phimbo"] = list_genres4;
            var movies = from m in _context.Movies
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.mov_title.ToLower().Contains(searchString.ToLower()));
            }

            ViewData["search"] = movies;

            return View();
        }

        [Route("{controller}/test")]
        public IActionResult Index1(int page = 1)
        {
            
            var dataPage = _context.Movies.GetPaged(page, 10);
            ViewData["detail"] = dataPage;
            return View();
        }

        [Route("{controller}/{action}/{id?}")]
        public IActionResult WatchMovie(int id)
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
            var lstMovie = from e in _context.Movies
                           select e;
            ViewData["theloai"] = list_genres1;
            ViewData["quocgia"] = list_genres2;
            ViewData["phimle"] = list_genres3;
            ViewData["phimbo"] = list_genres4;
            ViewData["lastest"] = lstMovie;

            var detail = from e in _context.Movies
                         where e.mov_id == id
                         select e;
            ViewData["detail"] = detail;
            return View();
        }
        public ViewResult Index2()
        {
            int Hour = DateTime.Now.Hour;
            ViewBag.Name = "Quan";
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
            List<string> lstResult = new List<string>();
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
