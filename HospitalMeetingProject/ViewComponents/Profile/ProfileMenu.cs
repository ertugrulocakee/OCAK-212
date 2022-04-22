using BLL.Concrete;
using DAL.EF;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HospitalMeetingProject.ViewComponents.Profile
{
    public class ProfileMenu : ViewComponent
    {

        private readonly UserManager<AppUser> userManager;
        PersonManager personManager = new PersonManager(new EFPersonDAL());

        public ProfileMenu(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var user = await userManager.FindByNameAsync(User.Identity.Name);

            var value = personManager.TGetByID(user.Id);

            return View(value);  

        }


    }
}
