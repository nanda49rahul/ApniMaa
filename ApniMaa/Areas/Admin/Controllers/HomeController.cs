#region Default Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
#endregion

#region Custom Namespaces
using ApniMaa.Attributes;
using ApniMaa.BLL.Models;
using ApniMaa.BLL.Interfaces;
using ApniMaa.BLL.Common;
#endregion

namespace ApniMaa.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        #region Variable Declaration
        private readonly IUserManager _userManager;
        private readonly IEmailTemplateManager _templateManager;
        private readonly ICMSManager _cmsManager;
        #endregion

        public HomeController(IUserManager userManager, IErrorLogManager errorLogManager, IEmailTemplateManager templateManager, ICMSManager cmsManager)
            : base(errorLogManager)
        {
            _userManager = userManager;
            _templateManager = templateManager;
            _cmsManager = cmsManager;
        }

        /// <summary>
        /// Admin : Login Page
        /// </summary>
        /// <returns></returns>
        [HttpGet, Public]
        public ActionResult Index()
        {
            return View(new LoginModal());
        }

        /// <summary>
        /// This will handle user login request
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AjaxOnly, HttpPost, Public]
        public JsonResult Login(LoginModal model)
        {
            //to do: Implement user login
            var data = _userManager.AdminLogin(model);
            if (data.Status == ActionStatus.Successfull)
            {
                data.Object = new UserModel
                {
                    FirstName = data.Object.FirstName,
                    LastName = data.Object.LastName,
                    Email = data.Object.Email,
                    UserID = data.Object.UserID,
                    IsApproved = true,
                    //IsSuperAdmin = data.Object.IsSuperAdmin
                };
            }
            else
            {
                data.Status = ActionStatus.Error;
                data.Message = "Invalid Credentials.";
            }
            if (data.Status == ActionStatus.Successfull)
            {
                //var user_data = data.Object;
                //CreateCustomAuthorisationCookie(model.UserName, false, new JavaScriptSerializer().Serialize(user_data));
                var PermissonAndDetailModel = new PermissonAndDetailModel();
                PermissonAndDetailModel.UserDetails = data.Object;
                PermissonAndDetailModel.ModulesModelList = _userManager.GetAllModulesAtAuthentication(data.Object.UserID);
                CreateCustomAuthorisationCookie(model.UserName, true, new JavaScriptSerializer().Serialize(PermissonAndDetailModel));
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Dashboard Page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Dashboard()
        {
            return View();
        }


        /// <summary>
        /// ForgetPassword View
        /// </summary>
        /// <returns></returns>
        [HttpGet, Public]
        public ActionResult ForgetPassword()
        {
            return View(new ForgotPasswordModel());
        }




    }
}