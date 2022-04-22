using DAL.Abstract;
using DAL.Concrete;
using DAL.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class EFBranchDAL : GenericRepository<Branch>, IBranchDAL
    {
        public List<Branch> GetBranchesListWithHospitals()
        {
            using (var c = new Context())
            {

                return c.Branches.Include(x => x.Hospital).ToList();

            }
        }
    }
}
