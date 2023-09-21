using Microsoft.AspNetCore.Mvc;
using Project.DAL.Concrete;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class DashboardFeatureStatistics : ViewComponent
    {
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Portfolios.Where(x=>x.Condition != 100).Count();
            ViewBag.v2 = c.Messages.Where(x => x.Status == true).Count();
            ViewBag.v3 = c.Messages.Where(x => x.Status == false).Count();
            ViewBag.v4 = c.Testimonials.Count();
            return View();
        }
    }
}
