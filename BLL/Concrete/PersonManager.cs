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
    public class PersonManager : IPersonService
    {

        IPersonDAL personDAL;

        public PersonManager(IPersonDAL personDAL)
        {
            this.personDAL = personDAL;
        }

        public void TAdd(AppUser t)
        {
            personDAL.Insert(t);    
        }

        public void TDelete(AppUser t)
        {
            personDAL.Delete(t);    
        }        

        public AppUser TGetByID(int id)
        {
            return personDAL.GetByID(id);   
        }

        public List<AppUser> TGetList()
        {
            return personDAL.GetList(); 
        }

        public List<AppUser> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(AppUser t)
        {
            personDAL.Update(t);    
        }
    }
}
