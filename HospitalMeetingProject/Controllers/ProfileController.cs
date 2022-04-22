using BLL.Concrete;
using DAL.EF;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HospitalMeetingProject.Controllers
{
    public class ProfileController : Controller
    {

        private readonly UserManager<AppUser> userManager;
        PersonManager personManager = new PersonManager(new EFPersonDAL());

        public ProfileController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {

            var user = await userManager.FindByNameAsync(User.Identity.Name);

            var value = personManager.TGetByID(user.Id);    

            return View(value);
        }
    }
}
