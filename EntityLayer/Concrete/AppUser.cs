using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {

       
        public string NameSurname { get; set; } 

        public string ImageUrl { get; set; }

        public string Hospital { get; set; }    

        public string Branch { get; set; }  

        public string UserType { get; set; }    



        //public List<Admin> Admins { get; set; } 

        //public List<Secretary> Secretaries { get; set; }

        //public List<Doctor> Doctors { get; set; }   

        //public List<Patient> Patients { get; set; } 


    }
}
