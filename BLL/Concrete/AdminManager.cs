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
    public class AdminManager : IAdminService
    {

        IAdminDAL adminDAL;

        public AdminManager(IAdminDAL adminDAL)
        {
            this.adminDAL = adminDAL;
        }

        public void TAdd(Admin t)
        {
            adminDAL.Insert(t); 
        }

        public void TDelete(Admin t)
        {
           adminDAL.Delete(t);          
        }

        public Admin TGetByID(int id)
        {
           return adminDAL.GetByID(id); 
        }

        public List<Admin> TGetList()
        {
            return adminDAL.GetList();  
        }

        public List<Admin> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Admin t)
        {
            adminDAL.Update(t); 

        }
    }
}
