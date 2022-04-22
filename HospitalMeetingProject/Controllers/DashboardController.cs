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
    [Authorize(Roles = "Admin,Secretary,Doctor,Patient")]
    public class DashboardController : Controller
    {

        private readonly UserManager<AppUser> userManager;

        MeetingManager meetingManager = new MeetingManager(new EFMeetingDAL());
        AnnouncementManager announcementManager = new AnnouncementManager(new EFAnnouncementDAL()); 
        HospitalManager hospitalManager = new HospitalManager(new EFHospitalDAL()); 
        PersonManager personManager = new PersonManager(new EFPersonDAL());

        public DashboardController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async  Task<IActionResult> Index()
        {

            var user = await userManager.FindByNameAsync(User.Identity.Name);   

            ViewBag.userNameSurname = user.NameSurname;
            ViewBag.userName = user.UserName;

            ViewBag.confirmationMeetingPatient = meetingManager.TGetList().Where(m => m.PatientUserName == user.UserName).Where(m => m.Status == true && m.Confirmation == true).Count();
            ViewBag.confirmationMeetingDoctor = meetingManager.TGetList().Where(m=>m.DoktorUserName == user.UserName).Where(m => m.Status == true && m.Confirmation == true).Count();
            ViewBag.meetingCountSecretary = meetingManager.GetMeetingListWithExtras().Where(m => m.Hospital.Name == user.Hospital).Where(m => m.Status == true && m.Confirmation == false).Count();
            ViewBag.meetingCountSecretaryConfirmation = meetingManager.GetMeetingListWithExtras().Where(m => m.Hospital.Name == user.Hospital).Where(m => m.Status == true && m.Confirmation == true).Count();
            ViewBag.hospitalCount = hospitalManager.TGetList().Where(m => m.Status == true).Count();

            ViewBag.announcationCount = announcementManager.TGetList().Where(m => m.Hospital == user.Hospital).Count();
            ViewBag.secretaryCount = personManager.TGetList().Where(m => m.UserType == "Secretary").Count();
            return View();
        }
    }
}
