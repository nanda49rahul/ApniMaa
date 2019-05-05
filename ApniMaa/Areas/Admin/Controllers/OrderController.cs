using ApniMaa.Attributes;
using ApniMaa.BLL;
using ApniMaa.BLL.Interfaces;
using ApniMaa.BLL.Models;
using ApniMaa.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApniMaa.Areas.Admin.Controllers
{
    public class OrderController : AdminBaseController
    {

        #region Private Data


        private readonly IOrderManager _OrderManager;
        private readonly ISelectListManager _SelectListManager;
        public OrderController(IErrorLogManager errorLogManager, IOrderManager OrderManager, ISelectListManager SelectListManager)
            : base(errorLogManager)
        {
            _OrderManager = OrderManager;
            _SelectListManager = SelectListManager;
        }

        #endregion

        public ActionResult ManageOrders()
        {
            ViewBag.SelectedTab = SelectedAdminTab.Order;
            var data = _OrderManager.GetOrderPagedList(PagingModel.DefaultModel("id"));
            return View(data);
        }

        [HttpPost, AjaxOnly]
        public JsonResult GetOrdersPagingList(PagingModel model)
        {
            var modal = _OrderManager.GetOrderPagedList(model);
            List<string> resultString = new List<string>();
            resultString.Add(RenderRazorViewToString("partials/_orderListing", modal));
            resultString.Add(modal.TotalCount.ToString());
            return JsonResult(resultString);
        }
    
        //[HttpPost, AjaxOnly, Public]
        //public JsonResult SetUserStatus(long UserId, int StatusId)
        //{
        //    var result = _OrderManager.SetUserStatus(UserId, StatusId);

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult UpdateUserProfile(UserModel model)
        //{
        //    ViewBag.SelectedTab = SelectedAdminTab.Users;
        //    return Json(_userManager.UpdateUserProfile(model));
        //}

        //public ActionResult _AddDishPartial()
        //{
        //    AddDishForMotherModel AddDishModel = new AddDishForMotherModel();
        //    AddDishModel.DishList = _SelectListManager.GetDishList();
        //    return PartialView("Partials/_AddDishPartial", AddDishModel);
        //}
        //public ActionResult UpdateUserDetails(int UserId)
        //{
        //    var result = _userManager.GetUserDetails(UserId);
        //    //result.Object.DishList = _SelectListManager.GetDishList();
        //    return View(result.Object);
        //}

        //[HttpPost, AjaxOnly, Public]
        //public JsonResult UpdateUserDetails(UserDetailModel model)
        //{
        //    var result = _userManager.UpdateUserDetails(model);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        //[AjaxOnly, HttpPost]
        //public JsonResult AddDishForMother(AddDishForMotherModel model)
        //{
        //    ViewBag.SelectedTab = SelectedAdminTab.Users;
        //    return JsonResult(_userManager.AddDishForMother(model));

        //}

        //[AjaxOnly, HttpPost]
        //public JsonResult GetMotherDishList(int MotherId)
        //{
        //    ViewBag.SelectedTab = SelectedAdminTab.Users;
        //    var modal = _userManager.GetMotherDishList(MotherId);
        //    List<string> resultString = new List<string>();
        //    resultString.Add(RenderRazorViewToString("Partials/_MotherDishListing", modal));
        //    return JsonResult(resultString);
        //}

        //[HttpPost, AjaxOnly, Public]
        //public JsonResult DeleteDish(int dishid)
        //{
        //    var result = _userManager.DeleteDish(dishid);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

    }
}