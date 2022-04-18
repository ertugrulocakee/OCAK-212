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
    public class BranchManager : IBranchService
    {

        IBranchDAL branchDAL;

        public void TAdd(Branch t)
        {
            branchDAL.Insert(t);
        }

        public void TDelete(Branch t)
        {
            branchDAL.Delete(t);    
        }

        public Branch TGetByID(int id)
        {
            return branchDAL.GetByID(id);   
        }

        public List<Branch> TGetList()
        {
            return branchDAL.GetList();
        }

        public List<Branch> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Branch t)
        {
            branchDAL.Update(t);    
        }
    }
}
