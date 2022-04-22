using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Announcement
    {

        [Key]
        public int AnnouncementID { get; set; } 

        [Required(ErrorMessage ="Duyuru Başlığı boş olamaz!")]
        [MaxLength(25,ErrorMessage ="Duyuru Başlığı maksimum 25 karakterden oluşabilir!")]
        public string AnnouncementTopic { get; set; }


        [Required(ErrorMessage = "Duyuru İçeriği boş olamaz!")]
        [MaxLength(200, ErrorMessage = "Duyuru İçeriği maksimum 200 karakterden oluşabilir!")]
        public string AnnouncementContent { get; set; } 
        
        public DateTime Date { get; set; }  

        public string Hospital { get; set; }  

        

    }
}
