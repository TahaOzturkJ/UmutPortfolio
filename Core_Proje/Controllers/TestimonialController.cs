using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Concrete;
using Project.DAL.EntityFramework;
using Project.ENTITY.Concrete;
using Project.UI.Models;
using System.Data;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EFTestimonialDAL());
        public IActionResult Index()
        {
            var values = testimonialManager.TGetList();
            return View(values);
        }
        
        public IActionResult DeleteTestimonial(int id)
        {
            var values = testimonialManager.TGetByID(id);
            testimonialManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {
            var values = testimonialManager.TGetByID(id);
            TestimonialViewModel model = new TestimonialViewModel();
            model.TestimonialID = values.TestimonialID;
            model.ClientName = values.ClientName;
            model.CompanyName = values.CompanyName;
            model.Comment = values.Comment;
            model.Title = values.Title;
            model.ImageUrl = values.ImageUrl;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(Testimonial tm,TestimonialViewModel tvm)
        {
            if (tvm.Image != null && Path.GetExtension(tvm.Image.FileName) != ".svg")
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(tvm.Image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/TestimonialImage/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await tvm.Image.CopyToAsync(stream);
                tm.ImageUrl = "/TestimonialImage/" + imagename;
            }
            else
            {
                tm.ImageUrl = testimonialManager.TGetByID(tvm.TestimonialID).ImageUrl;
            }

            testimonialManager.TUpdate(tm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTestimonial(Testimonial tm,TestimonialViewModel tvm)
        {
            if (tvm.Image != null && Path.GetExtension(tvm.Image.FileName) != ".svg")
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(tvm.Image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/TestimonialImage/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await tvm.Image.CopyToAsync(stream);
                tm.ImageUrl = "/TestimonialImage/" + imagename;
            }

            testimonialManager.TAdd(tm);
            return RedirectToAction("Index");
        }
    }
}
