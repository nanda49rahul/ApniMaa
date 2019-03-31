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
    public class UserController  : BaseController
    {

        #region Private Data


        IUserManager _userManager;
       
        public UserController(IErrorLogManager errorLogManager, IUserManager userManager)
            : base(errorLogManager)
        {
            _userManager = userManager;
        }

        #endregion

        public ActionResult ManageUsers()
        {
            
            var data = _userManager.GetUserPagedList(new PagingModel { PageNo = 1, RecordsPerPage = AppDefaults.PageSize, SortBy = "CreatedOn", SortOrder = "Desc" });
            return View(data);
        }

        [HttpPost, AjaxOnly]
        public JsonResult GetUserPagedList(PagingModel model, long UserRole, long UserStatus)
        {
            PagingResult<UserModel> modal = _userManager.GetUserPagedList(model, UserRole, UserStatus);
            List<string> resultString = new List<string>();
            resultString.Add(RenderRazorViewToString("_UserListing", modal));
            resultString.Add(modal.TotalCount.ToString());
            return Json(new ActionOutput { Status = ActionStatus.Successfull, Message = "", Results = resultString }, JsonRequestBehavior.AllowGet);
        }
    
        [HttpPost, AjaxOnly, Public]
        public JsonResult SetUserStatus(long UserId, int StatusId)
        {
            var result = _userManager.SetUserStatus(UserId, StatusId);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateUserProfile(UserModel model)
        {
            return Json(_userManager.UpdateUserProfile(model));
        }
        //[HttpPost, AjaxOnly, Public]
        //public JsonResult GetUserProfile(long UserId)
        //{
        //    string path = Server.MapPath("~/Content/Upload/");
        //    var model = _userManager.GetProfileInfo(UserId, path);
        //    ViewBag.CountryList = UserManager.GetCountryList();

        //    if (model.CountryId == null)
        //    {
        //        List<SelectListItem> StateList = new List<SelectListItem>();
        //        SelectListItem item = new SelectListItem();
        //        item.Selected = true;
        //        item.Text = "Select State";
        //        item.Value = "";
        //        StateList.Add(item);
        //        ViewBag.StateList = StateList;
        //    }
        //    else
        //    {
        //        ViewBag.StateList = UserManager.GetStateList(model.CountryId.Value);
        //    }


        //    if (model.StateId == null)
        //    {
        //        List<SelectListItem> CityList = new List<SelectListItem>();
        //        SelectListItem item1 = new SelectListItem();
        //        item1.Selected = true;
        //        item1.Text = "Select City";
        //        item1.Value = "";
        //        CityList.Add(item1);
        //        ViewBag.CityList = CityList;
        //    }
        //    else
        //    {
        //        ViewBag.CityList = UserManager.GetCityList(model.StateId.Value);
        //    }



        //    ViewBag.CategoryList = UserManager.GetCategoryList();

        //    if (model.Categories == null)
        //    {
        //        ViewBag.SubCategoryList = new List<SelectListItem>();
        //    }
        //    else
        //    {
        //        ViewBag.SubCategoryList = UserManager.GetSubCategoryList(model.Categories);
        //    }
        //    List<string> resultString = new List<string>();
        //    resultString.Add(RenderRazorViewToString("/Views/Shared/_Myprofile.cshtml", model));
        //    //resultString.Add(modal.TotalCount.ToString());
        //    return Json(new ActionOutput { Status = ActionStatus.Successfull, Message = "", Results = resultString }, JsonRequestBehavior.AllowGet);

        //    //return Json("", result);
        //    //return Json(result, JsonRequestBehavior.AllowGet);
        //}
        [AjaxOnly, HttpPost, Public]
        public JsonResult Login(LoginModal model)
        {
            //to do: Implement user login
            var data = _userManager.AdminLogin(model);
            
            //if (data.Status == ActionStatus.Successfull)
            //{
            //    //var user_data = data.Object;
            //    //CreateCustomAuthorisationCookie(model.UserName, false, new JavaScriptSerializer().Serialize(user_data));
            //    var PermissonAndDetailModel = new PermissonAndDetailModel();
            //    PermissonAndDetailModel.UserDetails = data.Object;
            //    PermissonAndDetailModel.ModulesModelList = _userManager.GetAllModulesAtAuthentication(data.Object.UserID);
            //    CreateCustomAuthorisationCookie(model.UserName, true, new JavaScriptSerializer().Serialize(PermissonAndDetailModel));
            //}
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}