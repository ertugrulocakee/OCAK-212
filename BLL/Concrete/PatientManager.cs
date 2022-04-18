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
    public class PatientManager : IPatientService
    {

        IPatientDAL patientDAL;

        public void TAdd(Patient t)
        {
            patientDAL.Insert(t);   
        }

        public void TDelete(Patient t)
        {
            patientDAL.Delete(t);
        }

        public Patient TGetByID(int id)
        {
            
            return patientDAL.GetByID(id);  

        }

        public List<Patient> TGetList()
        {
           
            return patientDAL.GetList();    

        }

        public List<Patient> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Patient t)
        {
            patientDAL.Update(t);

        }
    }
}
