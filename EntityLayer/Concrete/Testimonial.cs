using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Testimonial
    {
        [Key]
        public int testimonialID { get; set; }
       
        public string description { get; set; }

        public int AppUserId { get; set; } 

        public AppUser AppUser { get; set; }  
        
        public bool status { get; set; }    

    }

}
