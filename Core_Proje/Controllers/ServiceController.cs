using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Concrete;
using Project.DAL.EntityFramework;
using Project.ENTITY.Concrete;
using Project.UI.Models;
using System.Data;
using System.Runtime.Intrinsics.X86;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EFServiceDAL());

        public IActionResult Index()
        {
            var values = serviceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddService(Service service,ServiceViewModel svm)
        {
            serviceManager.TAdd(service);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteService(int id)
        {
            var values = serviceManager.TGetByID(id);
            serviceManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditService(int id)
        {
            var values = serviceManager.TGetByID(id);
            ServiceViewModel model = new ServiceViewModel();
            model.ServiceID = values.ServiceID;
            model.Title = values.Title;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditService(Service service,ServiceViewModel svm)
        {
            serviceManager.TUpdate(service);
            return RedirectToAction("Index");
        }
    }
}
