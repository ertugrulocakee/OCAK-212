using BLL.Concrete;
using DAL.EF;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMeetingProject.Controllers
{
    [Authorize(Roles = "Doctor")]
    public class DoctorController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        MeetingManager meetingManager = new MeetingManager(new EFMeetingDAL());

        public DoctorController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            var values = meetingManager.GetMeetingListWithExtras().Where(x => x.DoktorUserName == user.UserName).Where(x => x.Status == true && x.Confirmation == true).ToList();

            return View(values);
        }
    
    }
}
