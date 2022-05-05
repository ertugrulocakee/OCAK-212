using BLL.Concrete;
using DAL.EF;
using Microsoft.AspNetCore.Mvc;

namespace HospitalMeetingProject.Areas.MainPage.ViewComponents.TopBar
{
    public class Topbar : ViewComponent
    {
        ContactInfoManager contactInfoManager = new ContactInfoManager(new EFContactInfoDAL());

        public IViewComponentResult Invoke()
        {

            var value = contactInfoManager.TGetByID(1);

            return View(value); 
            

        }

    }
}
