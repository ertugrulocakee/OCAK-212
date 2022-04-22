using BLL.Concrete;
using DAL.EF;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMeetingProject.Controllers
{
    [Authorize(Roles = "Secretary")]
    public class SecretaryController : Controller
    {

        MeetingManager meetingManager = new MeetingManager(new EFMeetingDAL());
        PersonManager personManager = new PersonManager(new EFPersonDAL());

        private readonly UserManager<AppUser> userManager;

        public SecretaryController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {

            var user = await userManager.FindByNameAsync(User.Identity.Name);   

            var values = meetingManager.GetMeetingListWithExtras().Where(x=>x.Hospital.Name == user.Hospital ).Where(x => x.Status == true).ToList();

            return View(values);

        }

        public IActionResult DeleteMeeting(int id)
        {

            var value = meetingManager.TGetByID(id);

            value.Status = false;   

            meetingManager.TUpdate(value);


            return RedirectToAction("Index");   

        }

        [HttpGet]
        public async Task<IActionResult> UpdateMeeting(int id)
        {

            if (TempData["Message"] != null)
            {

                ViewBag.Message = TempData["Message"];

            }


            var value = meetingManager.TGetByID(id);

            var user = await userManager.FindByNameAsync(User.Identity.Name);



            var doctorList = (from i in personManager.TGetList().Where(m => m.Hospital == user.Hospital && m.UserType == "Doctor").ToList()
                              select new SelectListItem()
                              {

                                  Text = i.NameSurname + " -- " + i.Branch,
                                  Value = i.UserName

                              }).ToList();

            doctorList.Insert(0, new SelectListItem()
            {
                Text = "---Doktor Seçin---",
                Value = String.Empty

            });

            ViewBag.Doctor = doctorList;


            return View(value); 


        }


        [HttpPost]
        public  async Task<IActionResult> UpdateMeeting(Meeting meeting)
        {

            try
            {

                var doctor = personManager.TGetList().Where(m => m.UserType == "Doctor" && m.UserName == meeting.DoktorUserName).FirstOrDefault();
                meeting.DoctorName = doctor.NameSurname;
                meeting.DoktorUserName = doctor.UserName;
            }
            catch
            {

                TempData["Message"] = "Doktor Secilmelidir!";

                return RedirectToAction("UpdateMeeting", "Secretary");

            }



            if (ModelState.IsValid)
            {

                if (meeting.Date.Year >= DateTime.Now.Year)
                {

                    if (meeting.Date.Month >= DateTime.Now.Month)
                    {


                        if (meeting.Date.Day > DateTime.Now.Day)
                        {

                            var value = meetingManager.TGetByID(meeting.MeetingID);

                            value.Date = meeting.Date;
                            value.Confirmation = meeting.Confirmation;

                            value.DoctorName = meeting.DoctorName;
                            value.DoktorUserName = meeting.DoktorUserName;

                            meetingManager.TUpdate(value);

                            return RedirectToAction("Index","Secretary");

                        }
                        else
                        {

                            TempData["Message"] = "Lutfen ileri bir tarih girin!";

                             return RedirectToAction("UpdateMeeting", "Secretary");

                        }


                    }
                    else
                    {

                        TempData["Message"] = "Lutfen ileri bir tarih girin!";

                        return RedirectToAction("UpdateMeeting", "Secretary");

                    }

                }
                else
                {
                    TempData["Message"] = "Lutfen ileri bir tarih girin!";

                    return RedirectToAction("UpdateMeeting", "Secretary");

                }



            }
            else
            {

                var user = await userManager.FindByNameAsync(User.Identity.Name);



                var doctorList = (from i in personManager.TGetList().Where(m => m.Hospital == user.Hospital && m.UserType == "Doctor").ToList()
                                  select new SelectListItem()
                                  {

                                      Text = i.NameSurname + " -- " + i.Branch,
                                      Value = i.UserName

                                  }).ToList();

                doctorList.Insert(0, new SelectListItem()
                {
                    Text = "---Doktor Seçin---",
                    Value = String.Empty

                });

                ViewBag.Doctor = doctorList;

                return View();

            }

        }

    }
}
