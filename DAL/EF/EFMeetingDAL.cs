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
    public class EFMeetingDAL : GenericRepository<Meeting>, IMeetingDAL
    {
        public List<Meeting> GetListWithExtras()
        {

            using (var c = new Context())
            {

                var value = c.Meetings.Include(x => x.Hospital).ToList();

                return value;
            }

            
        }

        
    }
}
