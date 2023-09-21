using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Project.DAL.Concrete;
using Project.ENTITY.Concrete;
using Project.UI.Models;
using System.Globalization;
using System.Net;

namespace Project.UI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<User> _signInManager;

        Context c = new Context();

        public LoginController(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel ulvm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(ulvm.UserName, ulvm.Password, true, true);
                if (result.Succeeded && User.IsInRole("Admin"))
                {
                    var values = c.Users.Where(x => x.UserName == ulvm.UserName).ToArray();
                    string loggedname = values.First().Name;
                    string loggedsurname = values.First().Surname;

                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Hatalı kullanıcı adı veya şifre");
                }
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index/", "Login");
        }
    }
}
