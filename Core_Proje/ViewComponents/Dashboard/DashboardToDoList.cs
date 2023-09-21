using Microsoft.AspNetCore.Mvc;
using Project.BLL.Concrete;
using Project.DAL.EntityFramework;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class DashboardToDoList : ViewComponent
    {
        ToDoListManager ToDoListManager = new ToDoListManager(new EFToDoListDAL());

        public IViewComponentResult Invoke()
        {
            var values = ToDoListManager.TGetList();
            return View(values);
        }

    }
}
