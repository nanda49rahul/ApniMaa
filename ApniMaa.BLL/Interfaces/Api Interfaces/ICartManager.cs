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
    public interface ICartManager
    {
        ActionOutput AddDishToCart(AddToCartModel model);
        ActionOutput RemoveDishFromCart(int ID);
        ActionOutput OrderCartData(int UserID, bool IsGuest);
    }
}
