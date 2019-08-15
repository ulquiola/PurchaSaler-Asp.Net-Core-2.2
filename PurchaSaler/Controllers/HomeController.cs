using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurchaSaler.Models;
using PurchaSaler.ViewModels;

namespace PurchaSaler.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
             var list =(
                from g in db.Goods
                join s in db.Shops on  g.ShopID equals s.ShopID 
                join u in db.Users on s.UserID equals u.Id 
                select new IndexVM()
                {
                    GoodName=g.GoodsName,
                    GoodPath=g.GoodsPhoto,
                    Price=g.Price,
                    GoodDescibe=g.GoodsDescribe,
                    ShopName=s.ShopName,
                    UserName=u.UserName
                }
            ).ToList();            
            return View(list);
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
