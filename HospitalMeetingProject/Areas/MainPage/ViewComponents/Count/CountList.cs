using BLL.Concrete;
using DAL.EF;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HospitalMeetingProject.Areas.MainPage.ViewComponents.Count
{
    public class CountList : ViewComponent
    {

        HospitalManager hospitalManager = new HospitalManager(new EFHospitalDAL());
        PersonManager personManager = new PersonManager(new EFPersonDAL()); 

        public IViewComponentResult Invoke()
        {

            ViewBag.HospitalCount = hospitalManager.TGetList().Where(m=>m.Status == true).Count();  
            ViewBag.DoctorCount = personManager.TGetList().Where(m=>m.UserType == "Doctor").Count();   


            return View();

        }


    }
}
