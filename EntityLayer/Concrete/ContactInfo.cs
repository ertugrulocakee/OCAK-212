using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ContactInfo
    {
        [Key]
        public int id { get; set; } 

        [Required(ErrorMessage ="Adres bilgisi boş olamaz!")]
        [MaxLength(60,ErrorMessage ="Adres bilgisi maksimum 60 karakterden oluşabilir!")]
        public string address { get; set; }    

        [Required(ErrorMessage ="Telefon bilgisi boş olamaz!")]
        [Phone(ErrorMessage ="Lütfen bir telefon numarası giriniz!")]
        [MaxLength(30,ErrorMessage ="Telefon numarası maksimum 30 karakterden oluşabilir!")]
        public string phone { get; set; } 

        [Required(ErrorMessage ="E-posta adresi boş olamaz!")]
        [EmailAddress(ErrorMessage ="Lütfen bir e-posta adresi giriniz!")]
        [MaxLength (40,ErrorMessage ="E-posta adresi maksimum 40 karakterden oluşabilir!")]
        public string email { get; set; }   


    }
}
