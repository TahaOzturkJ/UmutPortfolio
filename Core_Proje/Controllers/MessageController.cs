using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Concrete;
using Project.DAL.EntityFramework;
using System.Data;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EFMessageDAL());

        public IActionResult Index()
        {
            var values = messageManager.TGetList();
            return View(values);
        }

        public IActionResult DeleteMessage(int id)
        {
            var values = messageManager.TGetByID(id);
            messageManager.TDelete(values);
            return RedirectToAction("Index");
        }

        public IActionResult ViewMessage(int id)
        {
            var values = messageManager.TGetByID(id);
            values.Status = false;
            messageManager.TUpdate(values);
            return View(values);
        }
    }
}
