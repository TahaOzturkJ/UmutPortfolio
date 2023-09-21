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
    public class SocialMediaController : Controller
    {
        SocialMediaManager socialMediaManager = new SocialMediaManager(new EFSocialMediaDAL());

        public IActionResult Index()
        {
            var values = socialMediaManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSocialMedia(SocialMedia sm,SocialMediaViewModel smvm)
        {
            smvm.Status = true;
            socialMediaManager.TAdd(sm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditSocialMedia(int id)
        {
            var values = socialMediaManager.TGetByID(id);
            SocialMediaViewModel model = new SocialMediaViewModel();
            model.SocialMediaID = values.SocialMediaID;
            model.Name = values.Name;
            model.Status = values.Status;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditSocialMedia(SocialMedia sm,SocialMediaViewModel smvm)
        {
            socialMediaManager.TUpdate(sm);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSocialMedia(int id)
        {
            var values = socialMediaManager.TGetByID(id);
            socialMediaManager.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
