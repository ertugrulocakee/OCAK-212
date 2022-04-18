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
    public class DoctorManager : IDoctorService
    {

        IDoctorDAL doctorDAL;

        public DoctorManager(IDoctorDAL doctorDAL)
        {
            this.doctorDAL = doctorDAL;
        }

        public void TAdd(Doctor t)
        {
             doctorDAL.Insert(t);

        }

        public void TDelete(Doctor t)
        {
            doctorDAL.Delete(t);
        }

        public Doctor TGetByID(int id)
        {
            return doctorDAL.GetByID(id);   
        }

        public List<Doctor> TGetList()
        {
            return doctorDAL.GetList();
        }

        public List<Doctor> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Doctor t)
        {
            doctorDAL.Update(t);  
            
        }
    }
}
