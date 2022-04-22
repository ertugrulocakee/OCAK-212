using BLL.Concrete;
using DAL.EF;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMeetingProject.ViewComponents.Announcement
{
    public class AnnouncementList : ViewComponent
    {


        AnnouncementManager announcementManager = new AnnouncementManager(new EFAnnouncementDAL());
        private readonly UserManager<AppUser> userManager;

        public AnnouncementList(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var user = await userManager.FindByNameAsync(User.Identity.Name);

            var value = announcementManager.TGetList().Where(m => m.Hospital == user.Hospital).Take(5).ToList();

            return View(value);  

        }

    }
}
