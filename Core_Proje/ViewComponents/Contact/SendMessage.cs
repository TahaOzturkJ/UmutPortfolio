using Microsoft.AspNetCore.Mvc;
using Project.BLL.Concrete;
using Project.DAL.EntityFramework;
using Project.ENTITY.Concrete;

namespace Core_Proje.ViewComponents.Contact
{
    public class SendMessage : ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EFMessageDAL());


        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
