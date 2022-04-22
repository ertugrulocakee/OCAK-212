using EntityLayer.Concrete;
using HospitalMeetingProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HospitalMeetingProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;

        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {

            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName,loginViewModel.Password, true, true);
                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {

                    ModelState.AddModelError("", "Hatalı kullanıcı adı ve şifre!");

                }
            }

            return View();

        }

        public async Task<IActionResult> LogOut()
        {

            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");

        }

    }
}
