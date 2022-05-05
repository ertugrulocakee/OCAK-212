using BLL.Concrete;
using DAL.EF;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HospitalMeetingProject.Areas.MainPage.Controllers
{
    [Area("MainPage")]
    [AllowAnonymous]
    [Route("MainPage/[controller]/[action]")]
    public class MainPageController : Controller
    {

        ContactManager contactManager = new ContactManager(new EFContactDAL());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(Contact contact)
        {

            contactManager.TAdd(contact);
            var values = JsonConvert.SerializeObject(contact);
            return Json(values);

        }

    }
}
