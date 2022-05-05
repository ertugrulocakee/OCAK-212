using BLL.Concrete;
using DAL.EF;
using Microsoft.AspNetCore.Mvc;

namespace HospitalMeetingProject.Areas.MainPage.ViewComponents.ContactInfo
{
    public class ContactInfo : ViewComponent
    {
        ContactInfoManager contactInfoManager = new ContactInfoManager(new EFContactInfoDAL());

        public IViewComponentResult Invoke()
        {


            return View(contactInfoManager.TGetByID(1));

        }

    }
}
