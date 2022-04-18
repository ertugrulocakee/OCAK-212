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
    public class SecretaryManager : ISecretaryService
    {

        ISecretaryDAL sercetaryDAL;

        public void TAdd(Secretary t)
        {
            sercetaryDAL.Insert(t); 
        }

        public void TDelete(Secretary t)
        {
            sercetaryDAL.Delete(t); 
        }

        public Secretary TGetByID(int id)
        {
            return sercetaryDAL.GetByID(id);    
        }

        public List<Secretary> TGetList()
        {
            return sercetaryDAL.GetList();  
        }

        public List<Secretary> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Secretary t)
        {
             sercetaryDAL.Update(t);
        }
    }
}
