using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HospitalMeetingProject.Models
{
    public class RegisterViewModel
    {

        [Required]
        [MaxLength(50, ErrorMessage = "Ad-Soyad en fazla 50 karaktere sahip olmalıdır!")]
        public string NameSurname { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Kullanıcı adı en fazla 20 karaktere sahip olmalıdır!")]
        public string UserName { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Parola en fazla 30 karaktere sahip olmalıdır!")]
        public string Password { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Parola en fazla 30 karaktere sahip olmalıdır!")]
        [Compare("Password", ErrorMessage = "Parolalar eşleşmelidir!")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Lütfen e-posta adresi girin!")]
        [MaxLength(30, ErrorMessage = "E-posta en fazla 30 karaktere sahip olmalıdır!")]
        public string Mail { get; set; }


        public string ImageUrl { get; set; }


        [Required(ErrorMessage = "Lütfen bir resim seçin!")]
        public IFormFile Picture { get; set; }

        public string Hospital { get; set; }

        public string UserType { get; set; }    

        public string Branch { get; set; }  


    }
}
