using ApniMaa.BLL.Interfaces;
using ApniMaa.BLL.Models;
using ApniMaa.Framework.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ApniMaa.Framework.Api.Helpers;

namespace ApniMaa.Areas.API
{
    public class CartController : BaseAPIController
    {
        private ICartManager _CartManager;
        public CartController(ICartManager CartManager)
        {
            _CartManager = CartManager;
        }

        public HttpResponseMessage AddToCart(AddToCartModel model)
        {
            var result = _CartManager.AddDishToCart(model);
            if (result.Status == ActionStatus.Successfull)
            {
                return new JsonContent(result.Message, Status.Success, result).ConvertToHttpResponseOK();
            }
            else
            {
                return new JsonContent(result.Message, Status.Failed, result).ConvertToHttpResponseOK();
            }
        }

        [HttpPost]
        public HttpResponseMessage RemoveDishFromCart(int ID)
        {
            var result = _CartManager.RemoveDishFromCart(ID);

            if (result.Status == ActionStatus.Successfull)
            {
                return new JsonContent(result.Message, Status.Success, result).ConvertToHttpResponseOK();
            }
            else
            {
                return new JsonContent(result.Message, Status.Failed, result).ConvertToHttpResponseOK();
            }
        }


        public HttpResponseMessage OrderCartData(int UserID, bool IsGuest = false)
        {
            var result = _CartManager.OrderCartData(UserID, IsGuest);

            if (result.Status == ActionStatus.Successfull)
            {
                return new JsonContent(result.Message, Status.Success, result).ConvertToHttpResponseOK();
            }
            else
            {
                return new JsonContent(result.Message, Status.Failed, result).ConvertToHttpResponseOK();
            }
        }
	}
}