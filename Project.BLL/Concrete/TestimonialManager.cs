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
    public class TestimonialManager : ITestimonialService
    {
        ITestimonialDAL _testimonialDAL;
        public TestimonialManager(ITestimonialDAL testimonialDAL)
        {
            _testimonialDAL = testimonialDAL;
        }

        public void TAdd(Testimonial t)
        {
            _testimonialDAL.Insert(t);
        }

        public void TDelete(Testimonial t)
        {
            _testimonialDAL.Delete(t);
        }

        public Testimonial TGetByID(int id)
        {
            return _testimonialDAL.GetByID(id);
        }

        public List<Testimonial> TGetList()
        {
            return _testimonialDAL.GetList();
        }

        public void TUpdate(Testimonial t)
        {
            _testimonialDAL.Update(t);
        }
    }
}
