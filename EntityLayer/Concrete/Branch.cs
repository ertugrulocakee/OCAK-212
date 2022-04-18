using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Branch
    {
        [Key]
        public int id { get; set; } 

        public string name { get; set; }    

        public bool status { get; set; }

        public virtual Hospital hospital { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }

    }
}
