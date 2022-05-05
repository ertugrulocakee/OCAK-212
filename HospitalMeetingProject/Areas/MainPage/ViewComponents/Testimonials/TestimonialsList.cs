using BLL.Concrete;
using DAL.EF;
using Microsoft.AspNetCore.Mvc;

namespace HospitalMeetingProject.Areas.MainPage.ViewComponents.Testimonials
{ 
    public class TestimonialsList : ViewComponent
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EFTestimonialDAL());

        public IViewComponentResult Invoke()
        {

            var values = testimonialManager.GetTestimonialsListWithUser();

            return View(values);      

        }

    }
}
