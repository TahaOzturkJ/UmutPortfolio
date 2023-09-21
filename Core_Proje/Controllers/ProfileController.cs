using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Concrete;
using Project.ENTITY.Concrete;
using Project.UI.Models;

namespace Project.UI.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<User> _userManager;

        public ProfileController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = values.Name;
            model.Surname = values.Surname;
            model.PictureURL = values.ImageURL;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel uevm)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (uevm.Picture != null && Path.GetExtension(uevm.Picture.FileName) != ".svg")
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(uevm.Picture.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/UserImage/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await uevm.Picture.CopyToAsync(stream);
                user.ImageURL = "/UserImage/"+imagename;
            }
            //else
            //{
            //    uevm.PictureURL = _userManager.FindByNameAsync(User.Identity.Name).Result.ImageURL;
            //}

            user.Name = uevm.Name;
            user.Surname = uevm.Surname;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, uevm.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
