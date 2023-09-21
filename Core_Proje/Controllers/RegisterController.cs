using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.ENTITY.Concrete;
using Project.UI.Models;

namespace Project.UI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<User> _userManager;

        public RegisterController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel urvm)
        {
            if (ModelState.IsValid)
            {
                User u = new User()
                {
                    Name = urvm.Name,
                    Surname = urvm.Surname,
                    Email = urvm.Mail,
                    UserName = urvm.UserName,
                    ImageURL = urvm.ImageURL
                };


                if (urvm.ConfirmPassword == urvm.Password)
                {
                    var result = await _userManager.CreateAsync(u, urvm.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }

            }
            return View();
        }
    }
}
