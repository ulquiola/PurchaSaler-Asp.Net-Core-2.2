using System.IO;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PurchaSaler.Models;
using Microsoft.AspNetCore.Hosting;

namespace PurchaSaler.Controllers
{
    public class MallController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ApplicationDbContext db;
        private readonly IHostingEnvironment hostingEvironment;

        public MallController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
             ApplicationDbContext db,
             IHostingEnvironment hostingEvironment)
        {
            this.db = db;
            this.hostingEvironment = hostingEvironment;
            this.userManager = userManager;
            this.signInManager = signInManager;

        }

        public IActionResult Index()
        {
            return View();
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
                    await stream.CopyToAsync(stream);
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
    }
}