using BLL.Concrete;
using DAL.EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalMeetingProject.Controllers
{
    [Authorize(Roles="Admin")]
    public class MessageController : Controller
    {

        ContactManager contactManager = new ContactManager(new EFContactDAL());

        public IActionResult Index()
        {
            var values = contactManager.TGetList();

            return View(values);

        }

        public IActionResult MessageDetail(int id)
        {

            var value = contactManager.TGetByID(id);    

            return View(value); 

        }

        public IActionResult DeleteMessage(int id)
        {

            var value = contactManager.TGetByID(id);

            contactManager.TDelete(value);

            return RedirectToAction("Index"); 
        }



    }
}
