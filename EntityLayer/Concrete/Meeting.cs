using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Meeting
    {
        [Key]
        public int MeetingID { get; set; }
        
        [Required(ErrorMessage ="Tarih boş olamaz!")]
        [DataType(DataType.DateTime,ErrorMessage ="Lütfen bir tarih ifadesi girin!")]
        public DateTime Date { get; set; }  

        public bool  Confirmation { get; set; } 

        public bool Status { get; set; }

        public string DoctorName { get; set; }  
        
        public string DoktorUserName { get; set; }

        public string PatientName { get; set; }

        public string PatientUserName { get; set; } 

       
        //public int DoctorID { get; set; }   
   
        //public int PatientID { get; set; }  

        public int HospitalID { get; set; }

        public  Hospital Hospital { get; set; }

        //public  Doctor Doctor { get; set; }

        //public  Patient Patient { get; set; }


    }
}
