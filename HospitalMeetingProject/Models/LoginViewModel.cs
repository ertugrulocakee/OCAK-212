using System.ComponentModel.DataAnnotations;

namespace HospitalMeetingProject.Models
{
    public class LoginViewModel
    {

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz!")]
        public string UserName { get; set; }


        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre boş bırakılamaz!")]
        public string Password { get; set; }


    }
}
