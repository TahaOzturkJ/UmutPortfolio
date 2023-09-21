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
    public class FeatureManager : IFeatureService
    {
        IFeatureDAL _featureDAL;

        public FeatureManager(IFeatureDAL featureDAL)
        {
            _featureDAL = featureDAL;
        }

        public void TAdd(Feature t)
        {
            _featureDAL.Insert(t);
        }

        public void TDelete(Feature t)
        {
            _featureDAL.Delete(t);
        }

        public Feature TGetByID(int id)
        {
            return _featureDAL.GetByID(id);
        }

        public Feature TGetFirst()
        {
            return _featureDAL.GetFirst();
        }

        public List<Feature> TGetList()
        {
            return _featureDAL.GetList();
        }

        public void TUpdate(Feature t)
        {
            _featureDAL.Update(t);
        }
    }
}
