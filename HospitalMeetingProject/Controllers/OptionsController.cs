using BLL.Concrete;
using DAL.EF;
using EntityLayer.Concrete;
using HospitalMeetingProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMeetingProject.Controllers
{
    public class OptionsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public OptionsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();

            model.NameSurname = value.NameSurname;
            model.ImageUrl = value.ImageUrl;
            model.UserName = value.UserName;
            model.Mail = value.Email;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
        {

            if (ModelState.IsValid)
            {

                PersonManager personManager = new PersonManager(new EFPersonDAL());

                var values = await _userManager.FindByNameAsync(User.Identity.Name);

                var users = personManager.TGetList().Where(x => x.Id != values.Id).Where(x => x.UserName == userEditViewModel.UserName || x.Email == userEditViewModel.Mail).ToList();


                if (users.Any())
                {

                    ViewBag.Message = "E-posta adresiniz ve Kullanici adiniz benzersiz olmalidir!";

                    return View();

                }


                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                user.Email = userEditViewModel.Mail;
                user.NameSurname = userEditViewModel.NameSurname;             
                user.UserName = userEditViewModel.UserName;


                if (userEditViewModel.Picture != null)
                {

                    string[] validFileTypes = { "gif", "jpg", "png" };
                    bool isValidType = false;


                    var resource = Directory.GetCurrentDirectory();
                    var extension = Path.GetExtension(userEditViewModel.Picture.FileName);

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
                        return View();
                    }

                    var imagename = Guid.NewGuid() + extension;
                    var saveLocation = resource + "/wwwroot/userimage/" + imagename;
                    var stream = new FileStream(saveLocation, FileMode.Create);
                    await userEditViewModel.Picture.CopyToAsync(stream);
                    user.ImageUrl = imagename;

                }


                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "Login");

                }

                return View();

            }
            else
            {


                return View();

            }

        }


        [HttpGet]
        public IActionResult PasswordChanger()
        {

            return View();

        }




        [HttpPost]
        public async Task<IActionResult> PasswordChanger(PasswordChangeViewModel passwordChangeViewModel)
        {

            if (ModelState.IsValid)
            {

                var user = await _userManager.FindByNameAsync(User.Identity.Name);


                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, passwordChangeViewModel.Password);

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "Login");

                }

                return View();

            }
            else
            {


                return View();

            }


        }


    }
}
