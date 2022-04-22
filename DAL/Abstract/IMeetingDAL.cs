﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IMeetingDAL : IGenericDAL<Meeting>
    {

        List<Meeting> GetListWithExtras();

       
        
    }
}
