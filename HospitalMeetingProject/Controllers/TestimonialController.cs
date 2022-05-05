using BLL.Concrete;
using BLL.ValidationRules;
using DAL.EF;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMeetingProject.Controllers
{
    [Authorize(Roles = "Patient")]
    public class TestimonialController : Controller
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EFTestimonialDAL());
        private readonly UserManager<AppUser> userManager;

        public TestimonialController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            var values = testimonialManager.GetTestimonialsListWithUser().Where(m => m.AppUser.UserName == user.UserName).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddTestimonial()
        {

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddTestimonial(Testimonial testimonial)
        {

            TestimonialValidation testimonialValidation = new TestimonialValidation();

            ValidationResult results = testimonialValidation.Validate(testimonial);


            if (results.IsValid)
            {


                var user = await userManager.FindByNameAsync(User.Identity.Name);

                testimonial.status = true;

                testimonial.AppUserId = user.Id;   

                testimonialManager.TAdd(testimonial);

                return RedirectToAction("Index", "Testimonial");

            }
            else
            {

                foreach (var item in results.Errors)
                {

                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }

            }


            return View();  

        }

        public IActionResult RemoveTestimonial(int id)
        {

            var value = testimonialManager.TGetByID(id);

            testimonialManager.TDelete(value);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {
            var value = testimonialManager.TGetByID(id);

            return View(value); 
        }

        [HttpPost]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {

            TestimonialValidation testimonialValidation = new TestimonialValidation();

            ValidationResult results = testimonialValidation.Validate(testimonial);


            if (results.IsValid)
            {

                var value = testimonialManager.TGetByID(testimonial.testimonialID);

                value.description = testimonial.description;

                testimonialManager.TUpdate(value);

                return RedirectToAction("Index", "Testimonial");

            }
            else
            {

                foreach (var item in results.Errors)
                {

                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }

            }


            return View();


        }


    }
}
