using BLL.Concrete;
using DAL.EF;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMeetingProject.Controllers
{
   
    public class AnnouncementController : Controller
    {

        AnnouncementManager announcementManager = new AnnouncementManager(new EFAnnouncementDAL());
        private readonly UserManager<AppUser> userManager;

        public AnnouncementController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        [Authorize(Roles ="Admin,Secretary,Doctor,Patient")]        
        public async Task<IActionResult> Index()
        {

            var user = await userManager.FindByNameAsync(User.Identity.Name);

            var value = announcementManager.TGetList().Where(m=>m.Hospital == user.Hospital); 

            return View(value.ToList());
        }


        [Authorize(Roles = "Secretary")]
        [HttpGet]
        public IActionResult AddAnnouncement()
        {

            return View();  

        }

        [HttpPost]  
        public async Task<IActionResult> AddAnnouncement(Announcement announcement)
        {

            if (ModelState.IsValid)
            {

                var user = await userManager.FindByNameAsync(User.Identity.Name);

                announcement.Hospital = user.Hospital;


                announcement.Date = DateTime.Now;


                announcementManager.TAdd(announcement);

                return RedirectToAction("Index");

            }
            else
            {

                return View();

            }
        }


        public IActionResult DeleteAnnouncement(int id)
        {

            var value = announcementManager.TGetByID(id);

            announcementManager.TDelete(value);

            return RedirectToAction("Index");

        }

        [Authorize(Roles = "Secretary")]
        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {

            var value = announcementManager.TGetByID(id);

            return View(value);

        }

        [HttpPost]
        public IActionResult UpdateAnnouncement(Announcement announcement)
        {
            if (ModelState.IsValid)
            {

                var value = announcementManager.TGetByID(announcement.AnnouncementID);

                value.AnnouncementContent = announcement.AnnouncementContent;
                value.AnnouncementTopic = announcement.AnnouncementTopic;
                value.Date = DateTime.Now;


                announcementManager.TUpdate(value);

                return RedirectToAction("Index");

            }
            else
            {

                return View();

            }


        }

        [Authorize(Roles = "Admin,Secretary,Doctor,Patient")]
        public IActionResult AnnouncementDetails(int id)
        {

            var value = announcementManager.TGetByID(id);

            return View(value);

        }

    }
}
