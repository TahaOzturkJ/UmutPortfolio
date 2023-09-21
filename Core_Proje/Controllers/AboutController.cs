using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Concrete;
using Project.DAL.EntityFramework;
using Project.ENTITY.Concrete;
using Project.UI.Models;
using System.Data;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EFAboutDAL());

        [HttpGet]
        public IActionResult Index()
        {
            var values = aboutManager.TGetFirst();
            AboutViewModel model = new AboutViewModel();
            model.AboutID = values.AboutID;
            model.Title = values.Title;
            model.Description = values.Description;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(About about,AboutViewModel avm)
        {
            aboutManager.TUpdate(about);
            return RedirectToAction("Index", "Default");
        }
    }
}
