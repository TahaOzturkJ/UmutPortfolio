using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Concrete;
using Project.DAL.EntityFramework;
using Project.ENTITY.Concrete;
using System.Data;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SubContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EFContactDAL());

        [HttpGet]
        public IActionResult Index()
        {
            var values = contactManager.TGetFirst();
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(Contact contact) 
        {
            contactManager.TUpdate(contact);
            return RedirectToAction("Index", "Default");
        }
    }
}
