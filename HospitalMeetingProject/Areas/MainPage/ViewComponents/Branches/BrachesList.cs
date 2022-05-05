using BLL.Concrete;
using DAL.EF;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HospitalMeetingProject.Areas.MainPage.ViewComponents.Branches
{
    public class BrachesList : ViewComponent
    {
        BranchManager branchManager = new BranchManager(new EFBranchDAL());
        public IViewComponentResult Invoke()
        {

            var values = branchManager.TGetList().Where(m=>m.Status == true).Select(m=>m.Name).Distinct();  

            return View(values.ToList());

        }

    }
}
