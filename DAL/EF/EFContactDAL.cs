using DAL.Abstract;
using EntityLayer.Concrete;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class EFContactDAL : GenericRepository<Contact>,IContactDAL
    {

    }
}
