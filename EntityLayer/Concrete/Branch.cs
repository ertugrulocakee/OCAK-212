using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Branch
    {
        [Key]
        public int BranchID { get; set; } 

        public string Name { get; set; }    

        public bool Status { get; set; }

        public int HospitalID { get; set; }

        public Hospital Hospital { get; set; }

        //public  List<Doctor> Doctors { get; set; }

    }
}
