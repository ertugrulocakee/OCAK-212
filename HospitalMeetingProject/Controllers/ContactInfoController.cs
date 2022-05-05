using BLL.Concrete;
using DAL.EF;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalMeetingProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactInfoController : Controller
    {

        ContactInfoManager contactInfoManager = new ContactInfoManager(new EFContactInfoDAL());

        [HttpGet]
        public IActionResult Index()
        {
            if (TempData["Message"] != null)
            {

                ViewBag.Message = TempData["Message"];
            }


            var value = contactInfoManager.TGetByID(1);
            return View(value);
        }

        [HttpPost]  
        public IActionResult Index(ContactInfo contactInfo)
        {

            if (ModelState.IsValid)
            {

                var value = contactInfoManager.TGetByID(contactInfo.id);

                value.phone = contactInfo.phone;
                value.email = contactInfo.email;
                value.address = contactInfo.address;

                contactInfoManager.TUpdate(value);

                TempData["Message"] = "Guncelleme basariyla gerceklesti!";
                return RedirectToAction("Index");

            }
            else
            {


                return View();

            }


        }
    }
}
