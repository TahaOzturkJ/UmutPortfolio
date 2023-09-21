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
    public class SocialMediaManager : ISocialMediaService
    {
        ISocialMediaDAL _socialMediaDAL;

        public SocialMediaManager(ISocialMediaDAL socialMediaDAL)
        {
            _socialMediaDAL = socialMediaDAL;
        }

        public void TAdd(SocialMedia t)
        {
            _socialMediaDAL.Insert(t);
        }

        public void TDelete(SocialMedia t)
        {
            _socialMediaDAL.Delete(t);
        }

        public SocialMedia TGetByID(int id)
        {
            return _socialMediaDAL.GetByID(id);
        }

        public List<SocialMedia> TGetList()
        {
            return _socialMediaDAL.GetList();
        }

        public void TUpdate(SocialMedia t)
        {
            _socialMediaDAL.Update(t);
        }
    }
}
