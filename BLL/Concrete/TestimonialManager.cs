using BLL.Abstract;
using DAL.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class TestimonialManager : ITestimonialService
    {

        ITestimonialDAL testimonialDAL;

        public TestimonialManager(ITestimonialDAL testimonialDAL)
        {
            this.testimonialDAL = testimonialDAL;
        }

        public List<Testimonial> GetTestimonialsListWithUser()
        {
            return testimonialDAL.GetTestimonialsWithUser();
        }

        public void TAdd(Testimonial t)
        {
            testimonialDAL.Insert(t);
        }

        public void TDelete(Testimonial t)
        {
            testimonialDAL.Delete(t);
        }

        public Testimonial TGetByID(int id)
        {
            return testimonialDAL.GetByID(id);  
        }

        public List<Testimonial> TGetList()
        {
            return testimonialDAL.GetList();
        }

        public List<Testimonial> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Testimonial t)
        {
            testimonialDAL.Update(t);
        }
    }
}
