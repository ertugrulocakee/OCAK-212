using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HospitalMeetingProject.Areas.MainPage.Models
{
    public class HospitalInfoViewModel
    {
        [Required(ErrorMessage ="Açıklama boş olamaz!")]
        [MaxLength(300,ErrorMessage ="Açıklama maksimum 300 karakterden oluşmaktadır!")]
        public string description { get; set; }

        [Required(ErrorMessage ="Resim seçilmelidir!")]
        public IFormFile hospitalImage { get; set; }

        public int HospitalID { get; set; }


    }
}
