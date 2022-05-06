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
    public class AboutManager : IAboutService
    {

        IAboutDAL aboutDAL;

        public AboutManager(IAboutDAL aboutDAL)
        {
            this.aboutDAL = aboutDAL;
        }

        public void TAdd(About t)
        {
            aboutDAL.Insert(t); 
        }

        public void TDelete(About t)
        {
            aboutDAL.Delete(t); 
        }

        public About TGetByID(int id)
        {
            return aboutDAL.GetByID(id);    
        }

        public List<About> TGetList()
        {
            return aboutDAL.GetList();
        }

        public List<About> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(About t)
        {
            aboutDAL.Update(t);     
        }
    }
}
