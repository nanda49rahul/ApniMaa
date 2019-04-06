using ApniMaa.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ApniMaa.DAL;

namespace ApniMaa.BLL.Interfaces
{
    public interface IDishManager
    {
        ActionOutput AddDish(AddDishModel model);
        ActionOutput ModifyDish(EditDishModel model);
        ActionOutput DeleteDish(int id);
        ActionOutput<EditDishModel> GetDishDetails(int Id);
        PagingResult<DishListingModel> GetDishPagedList(PagingModel model);
    }
}
