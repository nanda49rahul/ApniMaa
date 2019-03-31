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
    public class DashboardController : BaseController
    {
        #region Variable Declaration
        private readonly IDashboardManager _DashboardManager;

        #endregion

        public DashboardController(IDashboardManager DashboardManager, IErrorLogManager errorLogManager)
            : base(errorLogManager)
        {
            _DashboardManager = DashboardManager;

        }

        /// <summary>
        /// Index View 
        /// </summary>
        /// <returns></returns>
        //[Public]
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult myteam()
        {
            return View();
        }

        public ActionResult account()
        {
            return View();
        }

        public ActionResult EditCampaign()
        {
            return View();
        }

        [HttpGet, Public]
        public override ActionResult SignOut()
        {
            HttpCookie auth_cookie = Request.Cookies[Cookies.AuthorizationCookie];
            auth_cookie.Expires = DateTime.Now.AddDays(-30);
            Response.Cookies.Add(auth_cookie);
            return Redirect(Url.Action("Index", "Home"));
        }


    }
}