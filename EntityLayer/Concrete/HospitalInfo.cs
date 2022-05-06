using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class HospitalInfo
    {
        [Key]
        public int id { get; set; } 

        public string description { get; set; }

        public string hospitalImageUrl { get; set; }   

        public int HospitalID { get; set; }
        public Hospital Hospital { get; set; }

        public bool status { get; set; }    
       
    }
}
