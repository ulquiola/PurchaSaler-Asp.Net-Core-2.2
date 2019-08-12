using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PurchaSaler.Models;
using PurchaSaler.ViewModels;
using Microsoft.AspNetCore.Hosting;

namespace PurchaSaler.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IHostingEnvironment _hostingEnvironment;

        public AccountController(
            ApplicationDbContext db,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IHostingEnvironment hostingEnvironment )
        {
            this.db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM,IFormFile formFile)
        {
            string fileName=Guid.NewGuid()+ Path.GetExtension(formFile.FileName);
            //var filePath=Path.Combine(_hostingEnvironment.WebRootPath+"\\Files\\",fileName);//windows
            var filePath=Path.Combine(_hostingEnvironment.WebRootPath+"//Files//Avatar//",fileName);//linux
            if(formFile.Length>0)
            {
                using(var stream =new FileStream(filePath,FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }

            }
            if(ModelState.IsValid)
            {
                var user = new User()
                {
                    UserName = registerVM.UserName,
                    PhotoPath ="/Files/Avatar/" + fileName
                };
                var result = await _userManager.CreateAsync(user, registerVM.Password);
                if(result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
            }
            return View(registerVM);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(loginVM.UserName);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(
                        user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index","Home","");
                    }
                }
            }
            return View(loginVM);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", "");
        }
    }
}