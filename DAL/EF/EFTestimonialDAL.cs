using DAL.Abstract;
using DAL.Concrete;
using DAL.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class EFTestimonialDAL : GenericRepository<Testimonial>, ITestimonialDAL
    {
        public List<Testimonial> GetTestimonialsWithUser()
        {


            using (var c = new Context())
            {

                var value = c.Testimonials.Include(x => x.AppUser).ToList();

                return value;
            }

        }
    }
}
