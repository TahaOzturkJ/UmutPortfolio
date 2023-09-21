using Microsoft.AspNetCore.Mvc;
using Project.BLL.Concrete;
using Project.DAL.EntityFramework;

namespace Core_Proje.ViewComponents.Contact
{
    public class ContactDetails : ViewComponent
    {
        ContactManager contactManager = new ContactManager(new EFContactDAL());

        public IViewComponentResult Invoke()
        {
            var values = contactManager.TGetList();
            return View(values);
        }
    }
}
