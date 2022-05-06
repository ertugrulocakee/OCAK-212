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
    public class EFHospitalInfoDAL : GenericRepository<HospitalInfo>, IHospitalInfoDAL
    {
        public List<HospitalInfo> GetHospitalInfoWithHospital()
        {
            using (var c = new Context())
            {

                var value = c.HospitalInfos.Include(x => x.Hospital).ToList();

                return value;
            }
        }
    }
}
