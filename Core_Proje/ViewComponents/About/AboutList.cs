using Microsoft.AspNetCore.Mvc;
using Project.BLL.Concrete;
using Project.DAL.EntityFramework;

namespace Core_Proje.ViewComponents.About
{
    public class AboutList : ViewComponent
    {
        AboutManager aboutManager = new AboutManager(new EFAboutDAL());

        public IViewComponentResult Invoke()
        {
            var values = aboutManager.TGetList();
            return View(values);
        }
    }
}
