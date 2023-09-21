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
    public class PortfolioManager : IPortfolioService
    {
        IPortfolioDAL _portfolioManager;

        public PortfolioManager(IPortfolioDAL portfolioDAL)
        {
            _portfolioManager = portfolioDAL;
        }

        public void TAdd(Portfolio t)
        {
            _portfolioManager.Insert(t);
        }

        public void TDelete(Portfolio t)
        {
            _portfolioManager.Delete(t);
        }

        public Portfolio TGetByID(int id)
        {
            return _portfolioManager.GetByID(id);
        }

        public List<Portfolio> TGetList()
        {
            return _portfolioManager.GetList();
        }

        public void TUpdate(Portfolio t)
        {
            _portfolioManager.Update(t);
        }
    }
}
