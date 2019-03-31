#region Default Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
#endregion

#region Custom Namespaces
using ApniMaa.Attributes;
using ApniMaa.BLL.Interfaces;
using Ninject;
using ApniMaa.BLL.Models;
using System.Web.Script.Serialization;
#endregion

namespace ApniMaa.Controllers
{
    /// <summary>
    /// Home Controller 
    /// Created On: 10/04/2015
    /// </summary>
    public class HomeController : BaseController
    {
        #region Variable Declaration
        private readonly IUserManager _userManager;
    
        #endregion

        public HomeController(IUserManager userManager, IErrorLogManager errorLogManager)
            : base(errorLogManager)
        {
            _userManager = userManager;
          
        }

        /// <summary>
        /// Index View 
        /// </summary>
        /// <returns></returns>
        [Public]
        public ActionResult Index()
        {

            return RedirectToAction("Index", "Home", new { Area = "Admin" });
            //ViewBag.WelcomeMessage = _userManager.GetWelcomeMessage();
            //return View(new LoginModal());
        }

        ///// <summary>
        ///// This will handle user login request
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[AjaxOnly, HttpPost, Public]
        //public JsonResult Login(LoginModal model)
        //{
        //    //to do: Implement user login
        //    var data = _userManager.AdminLogin(model);
        //    //var data = new ActionOutput<UserDetails>();
        //    //if (model.UserName == "xicom" && model.Password == "technologies")
        //    //{
        //    if (data.Status == ActionStatus.Successfull)
        //    {
        //        data.Object = new UserDetails
        //        {
        //            FirstName = data.Object.FirstName,
        //            LastName = data.Object.LastName,
        //            UserEmail = data.Object.UserEmail,
        //            UserID = data.Object.UserID,
        //            IsAuthenticated = true,
        //            IsSuperAdmin = data.Object.IsSuperAdmin
        //        };
        //    }
        //    else
        //    {
        //        data.Status = ActionStatus.Error;
        //        data.Message = "Invalid Credentials.";
        //    }
        //    if (data.Status == ActionStatus.Successfull)
        //    {
        //        //var user_data = data.Object;
        //        //CreateCustomAuthorisationCookie(model.UserName, false, new JavaScriptSerializer().Serialize(user_data));
        //        var PermissonAndDetailModel = new PermissonAndDetailModel();
        //        PermissonAndDetailModel.UserDetails = data.Object;
        //        PermissonAndDetailModel.ModulesModelList = _userManager.GetAllModulesAtAuthentication(data.Object.UserID);
        //        CreateCustomAuthorisationCookie(model.UserName, true, new JavaScriptSerializer().Serialize(PermissonAndDetailModel));
        //    }
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}

        /// <summary>
        /// About Us Page
        /// </summary>
        /// <returns></returns>
        [Public]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Contact Us Page
        /// </summary>
        /// <returns></returns>
        [Public]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //[AjaxOnly, HttpPost, Public]
        //public ActionResult ForgotPassword(ForgotPasswordModel model)
        //{
        //    ForgotPasswordRequestModel result = _userManager.AddForgotPasswordRequest(model);
        //    if (result != null)
        //    {
        //        return Json(new ActionOutput { Status = ActionStatus.Successfull, Message = MessagesWebAdmin.OTP_SENT }, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(new ActionOutput { Status = ActionStatus.Error, Message = MessagesWebAdmin.USER_NOT_EXISTS }, JsonRequestBehavior.AllowGet);
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="token"></param>
        ///// <returns></returns>
        //[HttpGet, Public]
        //public ActionResult ResetPassword(string token)
        //{
        //    var resetPassword = new ResetPassword();
        //    resetPassword.Code = token;
        //    if (token == null || token == "")
        //    {

        //        resetPassword.Status = (int)AccountToken.Expired;
        //        return View(resetPassword);
        //    }
        //    else
        //    {
        //        var status = _userManager.GetForgotPasswordTokenDetails(token);
        //        resetPassword.Status = status;
        //        return View(resetPassword);
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[HttpPost, Public]
        //public ActionResult ResetPassword(ResetPassword model)
        //{
        //    ActionOutput action = _userManager.ResetPassword(model);
        //    if (action.Status == ActionStatus.Successfull)
        //    {
        //        model.Status = (int)AccountToken.Verified;
        //        return Json(new ActionOutput { Status = ActionStatus.Successfull, Message = "Password Changed" }, JsonRequestBehavior.AllowGet);
        //        //return View(action);
        //    }
        //    else
        //    {
        //        model.Status = (int)AccountToken.Expired;
        //        //return View(action);
        //        return Json(new ActionOutput { Status = ActionStatus.Error, Message = "Server Error" }, JsonRequestBehavior.AllowGet);
        //    }

        //}
    }
}