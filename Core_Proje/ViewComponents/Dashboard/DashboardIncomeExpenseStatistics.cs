using Microsoft.AspNetCore.Mvc;
using Project.DAL.Concrete;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class DashboardIncomeExpenseStatistics : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
