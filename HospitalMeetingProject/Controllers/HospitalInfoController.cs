using BLL.Concrete;
using DAL.EF;
using EntityLayer.Concrete;
using HospitalMeetingProject.Areas.MainPage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMeetingProject.Controllers
{
    [Authorize(Roles="Admin")]
    public class HospitalInfoController : Controller
    {
        HospitalInfoManager hospitalInfoManager = new HospitalInfoManager(new EFHospitalInfoDAL());
        HospitalManager hospitalManager = new HospitalManager(new EFHospitalDAL());

        public IActionResult Index()
        {
            var values = hospitalInfoManager.TGetHospitalInfoWithHospital().Where(m=>m.Hospital.Status==true && m.status == true).ToList();    

            return View(values);
        }

        public IActionResult DeleteHospitalInfo(int id)
        {

            var value = hospitalInfoManager.TGetByID(id);

            value.status = false;

            hospitalInfoManager.TUpdate(value);

            return RedirectToAction("Index");   

        }
      

        [HttpGet]
        public IActionResult AddHospitalInfo()
        {
            GetHospitals();
            return View(new HospitalInfoViewModel());

        }

        [HttpPost]
        public async Task<IActionResult> AddHospitalInfo(HospitalInfoViewModel hospitalInfoViewModel)
        {

            try
            {

                var hospital = hospitalManager.TGetList().Where(m => m.HospitalID == hospitalInfoViewModel.HospitalID).FirstOrDefault();

                hospitalInfoViewModel.HospitalID = hospital.HospitalID;

            }
            catch
            {

                ViewBag.Message = "Hastane Secilmelidir!";

                GetHospitals();

                return View();

            }


            string[] validFileTypes = { "gif", "jpg", "png" };
            bool isValidType = false;

            if (ModelState.IsValid)
            {

                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(hospitalInfoViewModel.hospitalImage.FileName);

                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (extension == "." + validFileTypes[i])
                    {
                        isValidType = true;
                        break;
                    }
                }

                if (!isValidType)
                {
                    ViewBag.Message = "Lutfen png,jpg ve gif dosyasi yukleyin!";
                    GetHospitals();
                    return View();
                }


                var imagename = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/hospitalimage/" + imagename;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await hospitalInfoViewModel.hospitalImage.CopyToAsync(stream);


                HospitalInfo hospitalInfo = new HospitalInfo();

                hospitalInfo.HospitalID = hospitalInfoViewModel.HospitalID;
                hospitalInfo.description = hospitalInfoViewModel.description;
                hospitalInfo.hospitalImageUrl = imagename;
                hospitalInfo.status = true;

                hospitalInfoManager.TAdd(hospitalInfo);

                return RedirectToAction("Index");

            }
            else
            {

              
                GetHospitals();

                return View();

            }


         }

         public IActionResult HospitalDetail(int id)
         {

            var value = hospitalInfoManager.TGetHospitalInfoWithHospital().Where(m=>m.id == id).FirstOrDefault();

            return View(value);

         }


        protected void GetHospitals()
        {

            var hospitalsList = (from i in hospitalManager.TGetList().Where(m => m.Status == true).ToList()
                                 select new SelectListItem()
                                 {

                                     Text = i.Name,
                                     Value = i.HospitalID.ToString()    

                                 }).ToList();

            hospitalsList.Insert(0, new SelectListItem()
            {
                Text = "---Hastane Seçin---",
                Value = ""

            }); 

            ViewBag.Hospital = hospitalsList;


        }



    }
}
