using Microsoft.AspNetCore.Mvc;
using Project.BLL.Concrete;
using Project.DAL.EntityFramework;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class DashboardMessageList : ViewComponent
    {
            MessageManager messageManager = new MessageManager(new EFMessageDAL());

            public IViewComponentResult Invoke()
            {
                var values = messageManager.TGetList().Take(5).OrderByDescending(x=>x.MessageID).ToList();
                return View(values);
            }
    }
}
