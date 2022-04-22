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
    [Authorize(Roles = "Admin")]
    public class AddSecretaryController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        PersonManager personManager = new PersonManager(new EFPersonDAL());
        HospitalManager hospitalManager = new HospitalManager(new EFHospitalDAL());
        

        public AddSecretaryController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;

        }

        [HttpGet]
        public IActionResult Index()
        {
            GetHospitals();
            return View(new RegisterViewModel());
        }

        [HttpPost]  
        public async Task<IActionResult> Index(RegisterViewModel register)
        {

            try
            {

                var hospital = hospitalManager.TGetList().Where(m => m.Name == register.Hospital).FirstOrDefault();

                register.Hospital = hospital.Name;

            }
            catch
            {

                ViewBag.Message = "Hastane Secilmelidir!";

                GetHospitals();

                return View();

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

                    ViewBag.Message = "E-posta adresiniz ve Kullanici adiniz benzersiz olmalidir!";
                    GetHospitals();

                    return View();

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
                    ViewBag.Message = "Lutfen png,jpg ve gif dosyasi yukleyin!";
                    GetHospitals();
                    return View();
                }


                var imagename = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/userimage/" + imagename;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await register.Picture.CopyToAsync(stream);

                

                AppUser appUser = new AppUser()
                {

                    NameSurname = register.NameSurname,
                    Email = register.Mail,
                    UserName = register.UserName,
                    ImageUrl = imagename,

                    Hospital = register.Hospital,
                    UserType = "Secretary",
                   
                };

                var result = await userManager.CreateAsync(appUser, register.Password);

                if (result.Succeeded)
                {

                    ViewBag.Message = register.NameSurname + " adli sekreter " + register.Hospital + " adli hastaneye basariyla atandi.";

                    GetHospitals();

                    return View();

                }
                else
                {

                    foreach (var item in result.Errors)
                    {

                        ModelState.AddModelError("", item.Description);

                    }

                }

            }


            GetHospitals();

            return View();


        }

        protected void GetHospitals()
        {

            var hospitalsList = (from i in hospitalManager.TGetList().Where(m=>m.Status == true).ToList()
                              select new SelectListItem()
                              {

                                  Text = i.Name,
                                  Value = i.Name

                              }).ToList();

            hospitalsList.Insert(0, new SelectListItem()
            {
                Text = "---Hastane Seçin---",
                Value = String.Empty

            });

            ViewBag.Hospital = hospitalsList;


        }


    }
}
