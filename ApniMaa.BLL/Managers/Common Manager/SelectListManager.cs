using ApniMaa.BLL.Interfaces;
using ApniMaa.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using ApniMaa.DAL;
using ApniMaa.BLL.Common;
using System.Threading;
using System.Web.Mvc;

namespace ApniMaa.BLL.Managers
{
    public class SelectListManager : BaseManager, ISelectListManager
    {
        List<SelectListItem> ISelectListManager.GetCategoryList()
        {
            return Context.Categories.Where(d => d.IsDeleted == false).ToList()
                    .Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() }).ToList();
        }

        List<SelectListItem> ISelectListManager.GetDishList()
        {
            return Context.Dishes.Where(d => d.IsDeleted == false).ToList()
                    .Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() }).ToList();
        }
    }


}
