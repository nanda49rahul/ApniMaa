using ApniMaa.BLL.Models;
using ApniMaa.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ApniMaa.BLL.Interfaces
{
    public interface IOrderManager
    {
        PagingResult<OrderListingModel> GetOrderPagedList(PagingModel model);
    }
}
