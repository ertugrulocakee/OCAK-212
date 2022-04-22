using BLL.Concrete;
using BLL.ValidationRules;
using DAL.EF;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMeetingProject.Controllers
{
    [Authorize(Roles = "Secretary")]
    public class BranchController : Controller
    {
      
        private readonly UserManager<AppUser> userManager;

        BranchManager branchManager = new BranchManager(new EFBranchDAL());

        HospitalManager hospitalManager = new HospitalManager(new EFHospitalDAL());
     
        
        public BranchController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {

            var user = await userManager.FindByNameAsync(User.Identity.Name);
      
            var values = branchManager.GetBranchesListWithHospitals().Where(m=>m.Status==true && m.Hospital.Name == user.Hospital).ToList();

            return View(values);

        }

        public IActionResult DeleteBranch(int id)
        {

            var value = branchManager.TGetByID(id);

            value.Status = false;

            branchManager.TUpdate(value);

            return RedirectToAction("Index");


        }


        [HttpGet]
        public IActionResult AddBranch()
        {

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddBranch(Branch branch)
        {

            BranchValidation branchValidation = new BranchValidation();

            ValidationResult results = branchValidation.Validate(branch);


            if (results.IsValid)
            {

                var user = await userManager.FindByNameAsync(User.Identity.Name);

                var hospital = hospitalManager.TGetList().Where(m => m.Name == user.Hospital).FirstOrDefault();
               
                branch.Status = true;

                branch.HospitalID = hospital.HospitalID; 

                branchManager.TAdd(branch);

                return RedirectToAction("Index", "Branch");

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
        public IActionResult UpdateBranch(int id)
        {

            var value = branchManager.TGetByID(id);

            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateBranch(Branch branch)
        {

            BranchValidation branchValidation = new BranchValidation();

            ValidationResult results = branchValidation.Validate(branch);


            if (results.IsValid)
            {

                var value = branchManager.TGetByID(branch.BranchID);

                value.Name = branch.Name;

                branchManager.TUpdate(value);

                return RedirectToAction("Index", "Branch");

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
