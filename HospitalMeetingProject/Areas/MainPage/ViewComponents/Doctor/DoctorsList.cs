using BLL.Concrete;
using DAL.EF;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HospitalMeetingProject.Areas.MainPage.ViewComponents.Doctor
{
    public class DoctorsList : ViewComponent
    {
        PersonManager personManager = new PersonManager(new EFPersonDAL());
        public IViewComponentResult Invoke()
        {
            var values = personManager.TGetList().Where(m => m.UserType == "Doctor").ToList();

            return View(values);  

        }

    }
}
