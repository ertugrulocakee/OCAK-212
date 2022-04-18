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
    public class HospitalManager : IHospitalService
    {

        IHospitalDAL hospitalDAL;

        public HospitalManager(IHospitalDAL hospitalDAL)
        {
            this.hospitalDAL = hospitalDAL;
        }

        public void TAdd(Hospital t)
        {
            hospitalDAL.Insert(t);  
        }

        public void TDelete(Hospital t)
        {
            hospitalDAL.Delete(t);  
        }

        public Hospital TGetByID(int id)
        {
            return hospitalDAL.GetByID(id);     
        }

        public List<Hospital> TGetList()
        {
            return hospitalDAL.GetList();   
        }

        public List<Hospital> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Hospital t)
        {
            hospitalDAL.Update(t);      
        }
    }
}
