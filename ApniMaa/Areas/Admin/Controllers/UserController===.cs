using followup.Attributes;
using followup.BLL.Interfaces;
using followup.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace followup.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        #region Variable Declaration
        private readonly IUserManager _userManager;
        private readonly IEmailTemplateManager _templateManager;
        #endregion

        public UserController(IUserManager userManager, IErrorLogManager errorLogManager, IEmailTemplateManager templateManager)
            : base(errorLogManager)
        {
            _userManager = userManager;
            _templateManager = templateManager;
        }

        #region User Management

        [HttpGet]
        public ActionResult ManageUsers()
        {
            ViewBag.SelectedTab = SelectedAdminTab.Users;
            var users = _userManager.GetUserPagedList(PagingModel.DefaultModel("CreatedAt"));
            return View(users);
        }

        [AjaxOnly, HttpPost]
        public JsonResult GetUsersPagingList(PagingModel model)
        {
            ViewBag.SelectedTab = SelectedAdminTab.Users;
            var modal = _userManager.GetUserPagedList(model);
            List<string> resultString = new List<string>();
            resultString.Add(RenderRazorViewToString("Partials/_userListing", modal));
            resultString.Add(modal.TotalCount.ToString());
            return JsonResult(resultString);
        }

        public ActionResult AddUser()
        {
            ViewBag.SelectedTab = SelectedAdminTab.Users;
            return View(new AddUserModel());
        }

        [AjaxOnly, HttpPost]
        public JsonResult AddUserDetails(AddUserModel model)
        {
            ViewBag.SelectedTab = SelectedAdminTab.Users;
            return JsonResult(_userManager.AddUserDetails(model));
        }

        public ActionResult EditUser(int userId)
        {
            ViewBag.SelectedTab = SelectedAdminTab.Users;
            var userModel = new UserModel();
            userModel = _userManager.GetUserDetailsByUserId(userId);
            return View(userModel);
        }

        [AjaxOnly, HttpPost]
        public JsonResult UpdateUserDetails(UserModel model)
        {
            ViewBag.SelectedTab = SelectedAdminTab.Users;
            return JsonResult(_userManager.UpdateUserDetails(model));
        }

        [AjaxOnly, HttpPost]
        public JsonResult DeleteUser(int userId)
        {
            ViewBag.SelectedTab = SelectedAdminTab.Users;
            return JsonResult(_userManager.DeleteUser(userId));
        }

        #endregion


        [AjaxOnly, HttpPost, Public]
        public ActionResult ForgotPassword(ForgotPasswordModel model)
        {
            ForgotPasswordRequestModel result = _userManager.AddForgotPasswordRequest(model, true);
            if (result != null)
            {
                return Json(new ActionOutput { Status = ActionStatus.Successfull, Message = MessagesWebAdmin.OTP_SENT }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new ActionOutput { Status = ActionStatus.Error, Message = MessagesWebAdmin.USER_NOT_EXISTS }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet, Public]
        public ActionResult ResetPassword(string token)
        {
            var resetPassword = new ResetPassword();
            resetPassword.Code = token;
            if (token == null || token == "")
            {

                resetPassword.Status = (int)AccountToken.Expired;
                return View(resetPassword);
            }
            else
            {
                var status = _userManager.GetForgotPasswordTokenDetails(token);
                resetPassword.Status = status;
                return View(resetPassword);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, Public]
        public ActionResult ResetPassword(ResetPassword model)
        {
            ActionOutput action = _userManager.ResetPassword(model);
            if (action.Status == ActionStatus.Successfull)
            {
                model.Status = (int)AccountToken.Verified;
                return View(model);
            }
            else
            {
                model.Status = (int)AccountToken.Expired;
                return View(model);
            }

        }
    }
}