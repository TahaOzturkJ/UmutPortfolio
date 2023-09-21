using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Project.BLL.Concrete;
using Project.DAL.Concrete;
using Project.DAL.EntityFramework;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class DashboardNavbarMessageList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
