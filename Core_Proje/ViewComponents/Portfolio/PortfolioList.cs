using Microsoft.AspNetCore.Mvc;
using Project.BLL.Concrete;
using Project.DAL.EntityFramework;

namespace Core_Proje.ViewComponents.Portfolio
{
    public class PortfolioList : ViewComponent
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EFPortfolioDAL());

        public IViewComponentResult Invoke()
        {
            var values = portfolioManager.TGetList().Where(x=>x.Condition == 100).ToList();
            return View(values);
        }

    }
}
