using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int id { get; set; }

        public string topWriting { get; set; }

        public string rightWriting { get; set; }   

    }
}
