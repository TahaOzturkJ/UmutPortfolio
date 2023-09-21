using Microsoft.AspNetCore.Mvc;
using Project.DAL.Concrete;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class DashboardOrderList : ViewComponent
    {
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            var values = c.Portfolios.ToList();
            return View(values);
        }
    }
}
