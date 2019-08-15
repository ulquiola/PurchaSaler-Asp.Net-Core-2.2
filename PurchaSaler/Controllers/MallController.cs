using System.Data;
using System.Runtime.InteropServices.ComTypes;
using System.IO;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PurchaSaler.Models;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using PurchaSaler.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace PurchaSaler.Controllers
{
    public class MallController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly ApplicationDbContext db;
        private readonly IHostingEnvironment hostingEvironment;

        public MallController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
             ApplicationDbContext db,
             IHostingEnvironment hostingEvironment)
        {
            this.db = db;
            this.hostingEvironment = hostingEvironment;
            this.userManager = userManager;
            this.signInManager = signInManager;

        }
///
        public IActionResult Index()
        {    
            var data =(
                from g in db.Goods
                join s in db.Shops on  g.ShopID equals s.ShopID 
                join u in db.Users on s.UserID equals u.Id 
                select new IndexVM()
                {
                    GoodName=g.GoodsName,
                    ShopName=s.ShopName,
                    UserName=u.UserName
                }
            ).ToList();            
            return View(data);
        }




        [HttpGet]
        public IActionResult AddShop()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddShop(Shops shops, IFormFile formFile)
        {
            string fileName = Guid.NewGuid()+Path.GetExtension(formFile.FileName);
            string filePath = Path.Combine(hostingEvironment.WebRootPath+"//Files//ShopImage//",fileName);
            if(formFile.Length>0)
            {
                using(var stream = new FileStream(filePath,FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
            }
            if (signInManager.IsSignedIn(User))
            {
                if (ModelState.IsValid)
                {
                   shops.ShopPhoto="/Files/ShopImage/"+fileName;
                   
                   var currentUser = await userManager.GetUserAsync(HttpContext.User);
                   shops.UserID = currentUser.Id;

                   await db.Shops.AddAsync(shops);
                   await db.SaveChangesAsync();
                   return RedirectToAction("Index","Home");
                }
            }
            else
            {
                return Content("请登录！");
            }
            return View(shops);
        }

        [HttpGet]
        public IActionResult AddGood()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGood(Goods goods,IFormFile formFile)
        {
            var fileName =Guid.NewGuid()+Path.GetExtension(formFile.FileName);
            var filePath =Path.Combine(hostingEvironment.WebRootPath+"//Files//GoodImage//",fileName);
            if(formFile.Length>0)
            {
                using(var stream = new FileStream(filePath,FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
            }
            if(signInManager.IsSignedIn(User))
            {
                if(ModelState.IsValid)
                {
                    goods.Time = DateTime.Now.ToLocalTime();
                    goods.GoodsPhoto ="/Files/GoodImage/"+ fileName;

                    var currentUser = await userManager.GetUserAsync(HttpContext.User);
                   
                    var currentShop =(
                        from s in db.Shops 
                        where s.UserID == currentUser.Id
                        select s.ShopID
                    ).FirstOrDefault();

                    goods.ShopID = Convert.ToInt32(currentShop);

                    await db.Goods.AddAsync(goods);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index","Home");
                }
            }
            return View(goods);
        }
    }
}