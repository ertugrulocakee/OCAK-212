using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HospitalMeetingProject.Models
{
    public class UserEditViewModel
    {

        [Required]
        [MaxLength(50, ErrorMessage = "Ad-Soyad en fazla 50 karaktere sahip olmalıdır!")]
        public string NameSurname { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Kullanıcı adı en fazla 20 karaktere sahip olmalıdır!")]
        public string UserName { get; set; }

        
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Lütfen e-posta adresi girin!")]
        [MaxLength(30, ErrorMessage = "E-posta en fazla 30 karaktere sahip olmalıdır!")]
        public string Mail { get; set; }


        public string ImageUrl { get; set; }

      
        public IFormFile Picture { get; set; }



    }
}
