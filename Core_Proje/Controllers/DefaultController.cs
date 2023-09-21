using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Concrete;
using Project.DAL.EntityFramework;
using Project.ENTITY.Concrete;

namespace Core_Proje.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }

        public PartialViewResult SidebarPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SendMessage(Message p, IFormCollection collection)
        {
            MessageManager messageManager = new MessageManager(new EFMessageDAL());

            if (!string.IsNullOrEmpty(collection["selectedService"]) != null)
            {
                p.SelectedServices = collection["selectedService"];
            }

            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Status = true;         
            messageManager.TAdd(p);

            return RedirectToAction("Index");
        }
    }
}
