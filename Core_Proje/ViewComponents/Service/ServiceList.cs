using Project.DAL.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project.BLL.Concrete;
using System.Net;

namespace Core_Proje.ViewComponents.Service
{
    public class ServiceList : ViewComponent
    {

        ServiceManager serviceManager = new ServiceManager(new EFServiceDAL());

        public IViewComponentResult Invoke()
        {
            var values = serviceManager.TGetList();
            return View(values);
        }

    }
}
