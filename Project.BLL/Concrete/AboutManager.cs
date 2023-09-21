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
    public class AboutManager : IAboutService
    {
        IAboutDAL _aboutDAL;

        public AboutManager(IAboutDAL aboutDAL)
        {
            _aboutDAL = aboutDAL;
        }

        public void TAdd(About t)
        {
            _aboutDAL.Insert(t);
        }

        public void TDelete(About t)
        {
            _aboutDAL.Delete(t);
        }

        public About TGetByID(int id)
        {
            return  _aboutDAL.GetByID(id);
        }

        public About TGetFirst()
        {
            return _aboutDAL.GetFirst();
        }

        public List<About> TGetList()
        {
            return _aboutDAL.GetList();
        }

        public void TUpdate(About t)
        {
            _aboutDAL.Update(t);
        }
    }
}
