using BLL.Concrete;
using DAL.EF;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HospitalMeetingProject.Areas.MainPage.ViewComponents.Hospitals
{
    public class HospitalsList : ViewComponent
    {
        HospitalInfoManager hospitalInfoManager = new HospitalInfoManager(new EFHospitalInfoDAL());

        public IViewComponentResult Invoke()
        {
            var values = hospitalInfoManager.TGetHospitalInfoWithHospital().Where(m => m.Hospital.Status == true && m.status == true).ToList();
            return View(values);
        }

    }
}
