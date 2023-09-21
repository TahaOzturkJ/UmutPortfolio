using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class DashboardVisitorMap : ViewComponent
    {
        public IViewComponentResult Invoke()
        { 
            return View();
        }
    }
}
