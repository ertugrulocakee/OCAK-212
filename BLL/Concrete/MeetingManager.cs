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
    public class MeetingManager : IMeetingService
    {

        IMeetingDAL meetingDAL;

        public MeetingManager(IMeetingDAL meetingDAL)
        {
            this.meetingDAL = meetingDAL;
        }

        public List<Meeting> GetMeetingListWithExtras()
        {
            return meetingDAL.GetListWithExtras();
        }

        public void TAdd(Meeting t)
        {
             meetingDAL.Insert(t);  

        }

        public void TDelete(Meeting t)
        {
            meetingDAL.Delete(t);   
        }

        public Meeting TGetByID(int id)
        {
            return meetingDAL.GetByID(id);      
        }

        public List<Meeting> TGetList()
        {
            return meetingDAL.GetList();        
        }

        public List<Meeting> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Meeting t)
        {
            meetingDAL.Update(t);
        }
    }
}
