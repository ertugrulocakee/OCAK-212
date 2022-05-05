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
    public class ContactInfoManager : IContactInfoService
    {

        IContactInfoDAL contactInfoDal;

        public ContactInfoManager(IContactInfoDAL contactInfoDal)
        {
            this.contactInfoDal = contactInfoDal;
        }

        public void TAdd(ContactInfo t)
        {
            contactInfoDal.Insert(t);
        }

        public void TDelete(ContactInfo t)
        {
            contactInfoDal.Delete(t);
        }

        public ContactInfo TGetByID(int id)
        {
            return contactInfoDal.GetByID(id);
        }

        public List<ContactInfo> TGetList()
        {
            return contactInfoDal.GetList();
        }

        public List<ContactInfo> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(ContactInfo t)
        {
            contactInfoDal.Update(t);
        }
    }
}
