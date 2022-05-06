using BLL.Concrete;
using DAL.EF;
using Microsoft.AspNetCore.Mvc;

namespace HospitalMeetingProject.Areas.MainPage.ViewComponents.About
{
    public class AboutList : ViewComponent
    {
        AboutManager aboutManager = new AboutManager(new EFAboutDAL());

        public IViewComponentResult Invoke()
        {
            var value = aboutManager.TGetByID(1);
            return View(value);  

        }

    }
}

