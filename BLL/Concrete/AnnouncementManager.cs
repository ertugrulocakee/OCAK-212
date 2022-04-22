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
    public class AnnouncementManager : IAnnouncementService
    {

        IAnnouncementDAL announcementDAL;

        public AnnouncementManager(IAnnouncementDAL announcementDAL)
        {
            this.announcementDAL = announcementDAL;
        }

        public void TAdd(Announcement t)
        {
           announcementDAL.Insert(t);   
        }

        public void TDelete(Announcement t)
        {
            announcementDAL.Delete(t);
        }

        public Announcement TGetByID(int id)
        {
            return announcementDAL.GetByID(id);
        }

        public List<Announcement> TGetList()
        {
            return announcementDAL.GetList();
        }

        public List<Announcement> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Announcement t)
        {
             announcementDAL.Update(t); 
        }
    }
}
