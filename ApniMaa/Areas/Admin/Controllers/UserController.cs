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
    public class UserController : AdminBaseController
    {

        #region Private Data


        private readonly IUserManager _userManager;
        private readonly ISelectListManager _SelectListManager;
        public UserController(IErrorLogManager errorLogManager, IUserManager userManager, ISelectListManager SelectListManager)
            : base(errorLogManager)
        {
            _userManager = userManager;
            _SelectListManager = SelectListManager;
        }

        #endregion

        public ActionResult ManageUsers()
        {
            ViewBag.SelectedTab = SelectedAdminTab.Users;
            var data = _userManager.GetUserPagedList(PagingModel.DefaultModel("CreatedOn"));
            return View(data);
        }

        [HttpPost, AjaxOnly]
        public JsonResult GetUsersPagingList(PagingModel model)
        {
            var modal = _userManager.GetUserPagedList(model);
            List<string> resultString = new List<string>();
            resultString.Add(RenderRazorViewToString("partials/_userListing", modal));
            resultString.Add(modal.TotalCount.ToString());
            return JsonResult(resultString);
        }
    
        [HttpPost, AjaxOnly, Public]
        public JsonResult SetUserStatus(long UserId, int StatusId)
        {
            var result = _userManager.SetUserStatus(UserId, StatusId);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult UpdateUserProfile(UserModel model)
        //{
        //    ViewBag.SelectedTab = SelectedAdminTab.Users;
        //    return Json(_userManager.UpdateUserProfile(model));
        //}

        public ActionResult _AddDishPartial()
        {
            AddDishForMotherModel AddDishModel = new AddDishForMotherModel();
            AddDishModel.DishList = _SelectListManager.GetDishList();
            return PartialView("Partials/_AddDishPartial", AddDishModel);
        }
        public ActionResult UpdateUserDetails(int UserId)
        {
            var result = _userManager.GetUserDetails(UserId);
            //result.Object.DishList = _SelectListManager.GetDishList();
            return View(result.Object);
        }

        [HttpPost, AjaxOnly, Public]
        public JsonResult GetUpdatedDishList()
        {
            var result = _SelectListManager.GetDishList();
            List<string> resultString = new List<string>();
            resultString.Add(RenderRazorViewToString("_selectListItems", result));

            return Json(new ActionOutput
            {
                Status = ActionStatus.Successfull,
                Results = resultString,
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, AjaxOnly, Public]
        public JsonResult UpdateUserDetails(UserDetailModel model)
        {
            var result = _userManager.UpdateUserDetails(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AjaxOnly, HttpPost]
        public JsonResult AddDishForMother(AddDishForMotherModel model)
        {
            ViewBag.SelectedTab = SelectedAdminTab.Users;
            return JsonResult(_userManager.AddDishForMother(model));

        }

        [AjaxOnly, HttpPost]
        public JsonResult GetMotherDishList(int MotherId)
        {
            ViewBag.SelectedTab = SelectedAdminTab.Users;
            var modal = _userManager.GetMotherDishList(MotherId);
            List<string> resultString = new List<string>();
            resultString.Add(RenderRazorViewToString("Partials/_MotherDishListing", modal));
            return JsonResult(resultString);
        }

        [HttpPost, AjaxOnly, Public]
        public JsonResult DeleteDish(int dishid)
        {
            var result = _userManager.DeleteDish(dishid);
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        //Not in use
        //[AjaxOnly, HttpPost, Public]
        //public JsonResult Login(LoginModal model)
        //{
        //    //to do: Implement user login
        //    var data = _userManager.AdminLogin(model);
            
        //    //if (data.Status == ActionStatus.Successfull)
        //    //{
        //    //    //var user_data = data.Object;
        //    //    //CreateCustomAuthorisationCookie(model.UserName, false, new JavaScriptSerializer().Serialize(user_data));
        //    //    var PermissonAndDetailModel = new PermissonAndDetailModel();
        //    //    PermissonAndDetailModel.UserDetails = data.Object;
        //    //    PermissonAndDetailModel.ModulesModelList = _userManager.GetAllModulesAtAuthentication(data.Object.UserID);
        //    //    CreateCustomAuthorisationCookie(model.UserName, true, new JavaScriptSerializer().Serialize(PermissonAndDetailModel));
        //    //}
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}
    }
}