using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Hospital
    {
        [Key]
        public int HospitalID { get; set; } 

        public string Name { get; set; }    

        public bool Status { get; set; }

        //public List<Doctor> Doctors { get; set; }

        //public List<Secretary> Secretaries { get; set; }    

        //public List<Patient> Patients { get; set; } 

        public  List<Branch> Branches { get; set; }
        
        public  List<Meeting> Meetings { get; set; }

    }

}
