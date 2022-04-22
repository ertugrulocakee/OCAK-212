using BLL.Concrete;
using BLL.ValidationRules;
using DAL.EF;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HospitalMeetingProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HospitalController : Controller
    {

        HospitalManager hospitalManager = new HospitalManager(new EFHospitalDAL());

        public IActionResult Index()
        {

            var values = hospitalManager.TGetList().Where(m => m.Status == true).ToList();

            return View(values);

        }

        public IActionResult DeleteHospital(int id)
        {

            var value = hospitalManager.TGetByID(id);

            value.Status = false;

            hospitalManager.TUpdate(value);

            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult AddHospital()
        {

            return View();

        }

        [HttpPost]
        public IActionResult AddHospital(Hospital hospital)
        {

            HospitalValidation hospitalValidation = new HospitalValidation();

            ValidationResult results = hospitalValidation.Validate(hospital);


            if (results.IsValid)
            {

                hospital.Status = true;

                hospitalManager.TAdd(hospital);

                return RedirectToAction("Index", "Hospital");

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


        [HttpGet]
        public IActionResult UpdateHospital(int id)
        {

            var value = hospitalManager.TGetByID(id);

            return View(value);


        }

        [HttpPost]
        public IActionResult UpdateHospital(Hospital hospital)
        {


            HospitalValidation hospitalValidation = new HospitalValidation();

            ValidationResult results = hospitalValidation.Validate(hospital);


            if (results.IsValid)
            {

                hospital.Status = true;

                hospitalManager.TUpdate(hospital);

                return RedirectToAction("Index", "Hospital");

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
