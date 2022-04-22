using BLL.Concrete;
using DAL.EF;
using EntityLayer.Concrete;
using HospitalMeetingProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMeetingProject.Controllers
{
    [Authorize(Roles = "Secretary")]
    public class AddDoctorController : Controller
    {

        private readonly UserManager<AppUser> userManager;
        PersonManager personManager = new PersonManager(new EFPersonDAL());
        BranchManager branchManager = new BranchManager(new EFBranchDAL()); 


        public AddDoctorController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
            
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {

            if (TempData["message"] != null)
            {

                ViewBag.Message = TempData["message"];

            }


            var user = await userManager.FindByNameAsync(User.Identity.Name);


            var branchesList = (from i in branchManager.GetBranchesListWithHospitals().Where(m => m.Hospital.Name == user.Hospital).Where(m => m.Status == true).ToList()
                                select new SelectListItem()
                                {

                                    Text = i.Name,
                                    Value = i.Name

                                }).ToList();

            branchesList.Insert(0, new SelectListItem()
            {
                Text = "---Branş Seçin---",
                Value = String.Empty

            });

            ViewBag.Branches = branchesList;

            return View(new RegisterViewModel());
        }

        [HttpPost]  
        public async Task<IActionResult> Index(RegisterViewModel register)
        {

            try
            {

                var branch = branchManager.TGetList().Where(m => m.Name == register.Branch).FirstOrDefault();

                register.Branch = branch.Name;

            }
            catch
            {

                TempData["message"] = "Brans Secilmelidir!";


                return RedirectToAction("Index", "AddDoctor");

            }


            string[] validFileTypes = { "gif", "jpg", "png" };
            bool isValidType = false;



            if (ModelState.IsValid)
            {

                PersonManager personManager = new PersonManager(new EFPersonDAL());

                var users = personManager.TGetList();

                users = users.Where(x => x.UserName == register.UserName || x.Email == register.Mail).ToList();


                if (users.Any())
                {

                    TempData["message"] = "E-posta adresiniz ve Kullanici adiniz benzersiz olmalidir!";

                    return RedirectToAction("Index", "AddDoctor");

                }

                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(register.Picture.FileName);

                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (extension == "." + validFileTypes[i])
                    {
                        isValidType = true;
                        break;
                    }
                }

                if (!isValidType)
                {
                    TempData["message"] = "Lutfen png,jpg ve gif dosyasi yukleyin!";

                    return RedirectToAction("Index", "AddDoctor");

                }


                var imagename = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/userimage/" + imagename;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await register.Picture.CopyToAsync(stream);

                var user = await userManager.FindByNameAsync(User.Identity.Name);

                AppUser appUser = new AppUser()
                {

                    NameSurname = register.NameSurname,
                    Email = register.Mail,
                    UserName = register.UserName,
                    ImageUrl = imagename,

                    Hospital = user.Hospital,
                    UserType = "Doctor",
                    Branch = register.Branch

                };

                var result = await userManager.CreateAsync(appUser, register.Password);

                if (result.Succeeded)
                {

                    TempData["message"] = register.NameSurname + " adli doktor icin " + register.Branch + " adli brans basariyla atandi.";

                    return RedirectToAction("Index", "AddDoctor");

                }
                else
                {

                    foreach (var item in result.Errors)
                    {

                        ModelState.AddModelError("", item.Description);

                    }

                }

            }


            var person = await userManager.FindByNameAsync(User.Identity.Name);


            var branchesList = (from i in branchManager.GetBranchesListWithHospitals().Where(m => m.Hospital.Name == person.Hospital).Where(m => m.Status == true).ToList()
                                select new SelectListItem()
                                {

                                    Text = i.Name,
                                    Value = i.Name

                                }).ToList();

            branchesList.Insert(0, new SelectListItem()
            {
                Text = "---Branş Seçin---",
                Value = String.Empty

            });

            ViewBag.Branches = branchesList;

            return View(new RegisterViewModel());

          
        }


      

    }
}
