using Microsoft.AspNetCore.Mvc;
using Project.DAL.EntityFramework;
using Project.BLL.Concrete;

namespace Core_Proje.ViewComponents.Testimonial
{
    public class TestimonialList : ViewComponent
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EFTestimonialDAL());

        public IViewComponentResult Invoke()
        {
            var values = testimonialManager.TGetList();
            return View(values);
        }
    }
}
