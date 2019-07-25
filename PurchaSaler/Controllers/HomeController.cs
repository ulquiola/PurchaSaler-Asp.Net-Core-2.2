using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PurchaSaler.Models;

namespace PurchaSaler.Controllers
{
    public class HomeController : Controller
    {
        private readonly DBContext _db;
        public HomeController(DBContext db)
        {
            _db=db;
        }
        public IActionResult Index()
        {
            return View(_db.Good.ToList());
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
