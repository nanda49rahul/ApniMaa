﻿using ApniMaa.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ApniMaa.BLL.Interfaces
{
    public interface ISelectListManager
    {
        List<SelectListItem> GetCategoryList();

        List<SelectListItem> GetDishList();
    }
    
}
