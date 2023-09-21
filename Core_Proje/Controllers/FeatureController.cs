using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Concrete;
using Project.DAL.EntityFramework;
using Project.ENTITY.Concrete;
using System.Data;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FeatureController : Controller
    {
        FeatureManager featureManager = new FeatureManager(new EFFeatureDAL());

        [HttpGet]
        public IActionResult Index()
        {
            var values = featureManager.TGetFirst();
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(Feature feature) 
        {
            featureManager.TUpdate(feature);
            return RedirectToAction("Index", "Default");
        }
    }
}
