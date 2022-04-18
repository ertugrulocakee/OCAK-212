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
        public int id { get; set; } 

        public string name { get; set; }    

        public bool status { get; set; }


        public virtual ICollection<Branch> Branches { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }

        public virtual ICollection<Secretary> Secretaries { get; set; }

        public virtual ICollection<Meeting> Meetings { get; set; }

    }

}
