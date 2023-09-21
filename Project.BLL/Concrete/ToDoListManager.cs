using Project.BLL.Abstract;
using Project.DAL.Abstract;
using Project.ENTITY.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Concrete
{
    public class ToDoListManager : IToDoListService
    {
        IToDoListDAL _ToDoListDAL;

        public ToDoListManager(IToDoListDAL ToDoListDAL)
        {
            _ToDoListDAL = ToDoListDAL;
        }

        public void TAdd(ToDoList t)
        {
            _ToDoListDAL.Insert(t);
        }

        public void TDelete(ToDoList t)
        {
            _ToDoListDAL.Delete(t);
        }

        public ToDoList TGetByID(int id)
        {
            return _ToDoListDAL.GetByID(id);
        }

        public List<ToDoList> TGetList()
        {
            return _ToDoListDAL.GetList();
        }

        public void TUpdate(ToDoList t)
        {
            _ToDoListDAL.Update(t);
        }
    }
}
