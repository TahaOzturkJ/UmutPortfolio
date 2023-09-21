using Project.BLL.Abstract;
using Project.DAL.Abstract;
using Project.DAL.EntityFramework;
using Project.ENTITY.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDAL _contactDAL;

        public ContactManager(IContactDAL contactDAL)
        {
            _contactDAL = contactDAL;
        }

        public void TAdd(Contact t)
        {
            _contactDAL.Insert(t);
        }

        public void TDelete(Contact t)
        {
            _contactDAL.Delete(t);
        }
        public Contact TGetFirst()
        {
            return _contactDAL.GetFirst();
        }

        public Contact TGetByID(int id)
        {
            return _contactDAL.GetByID(id);
        }

        public List<Contact> TGetList()
        {
            return _contactDAL.GetList();
        }

        public void TUpdate(Contact t)
        {
            _contactDAL.Update(t);
        }
    }
}
