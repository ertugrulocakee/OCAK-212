using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Meeting
    {
        [Key]
        public int id { get; set; }
        
        public DateTime date { get; set; }  

        public bool  confirmation { get; set; } 

        public bool status { get; set; }

        public virtual Hospital hospital { get; set; }

        public virtual Doctor doctor { get; set; }

        public virtual Patient patient { get; set; }




    }
}
