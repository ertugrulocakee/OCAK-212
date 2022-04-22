using BLL.Concrete;
using DAL.Concrete;
using DAL.EF;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMeetingProject.Controllers
{
    [Authorize(Roles = "Patient")]
    public class MeetingController : Controller
    {

        MeetingManager meetingManager = new MeetingManager(new EFMeetingDAL());
        HospitalManager hospitalManager = new HospitalManager(new EFHospitalDAL());
        PersonManager personManager = new PersonManager(new EFPersonDAL());
    


        private readonly UserManager<AppUser> userManager;

        public MeetingController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

      
        public async Task<IActionResult> Index()
        {

            var user = await userManager.FindByNameAsync(User.Identity.Name);

            var values = meetingManager.GetMeetingListWithExtras().Where(x => x.PatientUserName == user.UserName).Where(x => x.Status == true && x.Confirmation == true).ToList();

            return View(values);
        }

      
       
        [HttpGet]
        public async Task<IActionResult> AddMeeting()
        {

            if(TempData["Message"] != null)
            {

                ViewBag.Message = TempData["Message"];  

            }

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

        
        [HttpPost]
        public async Task<IActionResult> AddMeeting(Meeting meeting)
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

                return RedirectToAction("AddMeeting", "Meeting");

            }


         
            if (ModelState.IsValid)
            {

                if (meeting.Date.Year >= DateTime.Now.Year)
                {

                    if (meeting.Date.Month >= DateTime.Now.Month)
                    {


                        if (meeting.Date.Day > DateTime.Now.Day)
                        {


                            meeting.Status = true;
                            meeting.Confirmation = false;

                            var user = await userManager.FindByNameAsync(User.Identity.Name);

                            meeting.PatientName = user.NameSurname;
                            meeting.PatientUserName = user.UserName;    

                            var hospital = hospitalManager.TGetList().Where(m => m.Name == user.Hospital).FirstOrDefault();
                            meeting.HospitalID = hospital.HospitalID;

                            meetingManager.TAdd(meeting);

                            return RedirectToAction("Index");

          
                        }
                        else
                        {

                            TempData["Message"] = "Lutfen ileri bir tarih girin!";
       
                            return RedirectToAction("AddMeeting", "Meeting");


                        }


                    }
                    else
                    {

                        TempData["Message"] = "Lutfen ileri bir tarih girin!";


                        return RedirectToAction("AddMeeting", "Meeting");

                    }

                }
                else
                {
                    TempData["Message"] = "Lutfen ileri bir tarih girin!";

               
                    return RedirectToAction("AddMeeting", "Meeting");

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
