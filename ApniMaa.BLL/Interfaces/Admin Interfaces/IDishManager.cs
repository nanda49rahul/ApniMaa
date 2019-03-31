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
        ActionOutput AddDish(Dish model);
        ActionOutput ModifyDish(Dish model);
        ActionOutput DeleteDish(Dish model);
        ActionOutput<DishModel> GetDishDetails(int Id);
        PagingResult<DishModel> GetDishPagedList(PagingModel model);
    }
}
