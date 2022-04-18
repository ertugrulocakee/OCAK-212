using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Patient
    {

        [Key]
        public int id { get; set; } 
        
        public int age { get; set; }    
        public string gender { get; set; }  
       
        public bool status { get; set; }

        public virtual Hospital hospital { get; set; }

        public virtual List<Meeting> Meetings { get; set; }

        public virtual AppUser appUser { get; set; }


    }
}
