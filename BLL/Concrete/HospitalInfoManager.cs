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
    public class HospitalInfoManager : IHospitalInfoService
    {

        IHospitalInfoDAL hospitalInfoDAL;

        public HospitalInfoManager(IHospitalInfoDAL hospitalInfoDAL)
        {
            this.hospitalInfoDAL = hospitalInfoDAL;
        }

        public void TAdd(HospitalInfo t)
        {
            hospitalInfoDAL.Insert(t);
        }

        public void TDelete(HospitalInfo t)
        {
            hospitalInfoDAL.Delete(t);
        }

        public HospitalInfo TGetByID(int id)
        {
            return hospitalInfoDAL.GetByID(id);
        }

        public List<HospitalInfo> TGetHospitalInfoWithHospital()
        {
            return hospitalInfoDAL.GetHospitalInfoWithHospital();
        }

        public List<HospitalInfo> TGetList()
        {
            return hospitalInfoDAL.GetList();
        }

        public List<HospitalInfo> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(HospitalInfo t)
        {
            hospitalInfoDAL.Update(t);
        }
    }
}
