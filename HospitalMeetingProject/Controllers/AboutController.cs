using BLL.Concrete;
using BLL.ValidationRules;
using DAL.EF;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace HospitalMeetingProject.Controllers
{
    [Authorize(Roles="Admin")]
    public class AboutController : Controller
    {

        AboutManager aboutManager = new AboutManager(new EFAboutDAL());

        [HttpGet]
        public IActionResult Index()
        {
            if (TempData["Message"] != null)
            {

                ViewBag.Message = TempData["Message"];
            }

            var value = aboutManager.TGetByID(1);

            return View(value);
        }


        [HttpPost]  
        public IActionResult Index(About about)
        {

            AboutValidation  validation = new AboutValidation();

            ValidationResult results = validation.Validate(about);

            if (results.IsValid)
            {

                var value = aboutManager.TGetByID(about.id);

                value.topWriting = about.topWriting;
                value.rightWriting = about.rightWriting;

                aboutManager.TUpdate(value);

                TempData["Message"] = "Hakkimda basariyla guncellendi.";

                return RedirectToAction("Index");   

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
