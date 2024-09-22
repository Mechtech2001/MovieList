using Microsoft.AspNetCore.Mvc;
using MovieList.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;


namespace MovieList.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private MovieContext context { get; set; }

        public HomeController(MovieContext ctx) => context = ctx;


        public IActionResult Index()
        {
            var movies = context.Movies.Include(m =>m.Genre).OrderBy(m => m.Name).ToList();
            return View(movies);
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
