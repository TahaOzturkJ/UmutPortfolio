using Project.DAL.Abstract;
using Project.DAL.Repository;
using Project.ENTITY.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.EntityFramework
{
    public class EFAboutDAL:GenericRepository<About>,IAboutDAL
    {

    }
}
