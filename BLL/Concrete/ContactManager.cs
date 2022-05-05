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
    public class ContactManager : IContactService
    {
        IContactDAL contactDAL;

        public ContactManager(IContactDAL contactDAL)
        {
            this.contactDAL = contactDAL;
        }

        public void TAdd(Contact t)
        {
            contactDAL.Insert(t);
        }

        public void TDelete(Contact t)
        {
            contactDAL.Delete(t);
        }

        public Contact TGetByID(int id)
        {
            return contactDAL.GetByID(id);  
        }

        public List<Contact> TGetList()
        {
            return contactDAL.GetList();    
        }

        public List<Contact> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Contact t)
        {
            contactDAL.Update(t);
        }
    }
}
