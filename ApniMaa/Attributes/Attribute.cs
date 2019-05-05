using Ninject;
using ApniMaa.Areas.API;
using ApniMaa.BLL.Common;
using ApniMaa.BLL.Interfaces;
using ApniMaa.BLL.Models;
using ApniMaa.Framework.Api;
using ApniMaa.Framework.Api.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Mvc;
using ApniMaa.BLL.Managers;

namespace ApniMaa.Attributes
{
    public class AuthenticateUser : Attribute { }

    public class Public : Attribute { }

    public class MemberAccess : Attribute { }

    public class AjaxOnlyAttribute : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo)
        {
            return controllerContext.RequestContext.HttpContext.Request.IsAjaxRequest();
        }
    }

    public class ModuleAccessAttribute : ActionMethodSelectorAttribute
    {
        private int id { get; set; }

        public ModuleAccessAttribute(int id)
        {
            this.id = id;
        }

        public override bool IsValidForRequest(ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo)
        {
            return controllerContext.RequestContext.HttpContext.Request.IsAjaxRequest();
        }
    }

    /// <summary>
    /// This will be used to set No Cache For Controller Actions
    /// </summary>
    public class NoCacheAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
            filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            filterContext.HttpContext.Response.Cache.SetNoStore();
            base.OnResultExecuting(filterContext);
        }
    }

    /// <summary>
    /// This will be used to skip model validations
    /// </summary>
    public class IgnoreModelErrorsAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        private string keysString;

        public IgnoreModelErrorsAttribute(string keys)
            : base()
        {
            this.keysString = keys;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ModelStateDictionary modelState = filterContext.Controller.ViewData.ModelState;
            string[] keyPatterns = keysString.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < keyPatterns.Length; i++)
            {
                string keyPattern = keyPatterns[i]
                    .Trim()
                    .Replace(@".", @"\.")
                    .Replace(@"[", @"\[")
                    .Replace(@"]", @"\]")
                    .Replace(@"\[\]", @"\[[0-9]+\]")
                    .Replace(@"*", @"[A-Za-z0-9]+");
                IEnumerable<string> matchingKeys = modelState.Keys.Where(x => Regex.IsMatch(x, keyPattern));
                foreach (string matchingKey in matchingKeys)
                    modelState[matchingKey].Errors.Clear();
            }
        }


    }

    /// <summary>
    /// validates the incomming model
    /// </summary>
    public class ValidateModel : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response = new JsonContent("Validation Error!", Status.Failed).ConvertToHttpResponseOK();
            }
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            new UserManager().Dispose();
            base.OnActionExecuted(actionExecutedContext);
        }
    }

    /// <summary>
    /// raised whenever any exception is encounteted in the application
    /// </summary>
    public class HandelExceptionFilter : Attribute { }
    public class HandelExceptionAttribute : ExceptionFilterAttribute
    {
        [Inject]
        public IErrorLogManager _errorLogManager { get; set; }

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var ex = actionExecutedContext.Exception;
            try
            {
                //Log exception in database
                _errorLogManager.LogExceptionToDatabase(ex);
            }
            catch (Exception)
            {
                System.IO.StreamWriter sw = null;
                try
                {
                    sw = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath("~/ErrorLog.txt"), true);
                    sw.WriteLine(ex.Message);
                    sw.WriteLine("http://jsonformat.com/");
                    sw.WriteLine(ex); sw.WriteLine(""); sw.WriteLine("");
                }
                catch { }
                finally { sw.Close(); }
            }
            actionExecutedContext.Response = new JsonContent("An Unexpected Error Has Occured!", Status.Failed).ConvertToHttpResponseOK();
        }
    }

    /// <summary>
    /// Checks if the incomming user is authorized at the time any function in about to execute 
    /// </summary>
    public class CheckAuthorizationFilter : Attribute { }
    public class CheckAuthorizationAttribute : System.Web.Http.AuthorizeAttribute
    {
        [Inject]
        public IUserManager _userManager { get; set; }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            try
            {
                if ((actionContext.Request.Method != HttpMethod.Post && actionContext.Request.Method != HttpMethod.Get))
                {
                    actionContext.Response = new JsonContent("Only POST and GET requests are allowed.", Status.Failed).ConvertToHttpResponseOK();
                }


                var baseController = (BaseAPIController)actionContext.ControllerContext.Controller;
                var skipAuthorization = actionContext.ActionDescriptor.GetCustomAttributes<SkipAuthorization>().Any();
                var skipAuthentication = actionContext.ActionDescriptor.GetCustomAttributes<SkipAuthentication>().Any();
                var sessionToken = actionContext.Request.Headers.Any(m => m.Key == " ") ? actionContext.Request.Headers.GetValues("SessionId").FirstOrDefault() : null;
                var UniqueDeviceId = actionContext.Request.Headers.Any(m => m.Key == "UniqueDeviceId") ? actionContext.Request.Headers.GetValues("UniqueDeviceId").FirstOrDefault() : null;


                if (!skipAuthentication)
                {
                    var secretKey = Config.ApniMaaSecretKey;
                    var clientHash = actionContext.Request.Headers.GetValues("ClientHash").FirstOrDefault();
                    var timeStamp = actionContext.Request.Headers.GetValues("TimeStamp").FirstOrDefault();

                    if (sessionToken == null)
                    {
                        var validationHash = CommonMethods.HashCode(string.Format("{0}{1}", timeStamp, secretKey));
                        if (!validationHash.Equals(clientHash, StringComparison.InvariantCultureIgnoreCase))
                        {
                           actionContext.Response = new JsonContent("Request could not be authenticated. Invalid hash encountered!", Status.Failed).ConvertToHttpResponseOK();
                           return;
                        }
                    }
                    else
                    {
                        var validationHash = CommonMethods.HashCode(string.Format("{0}{1}{2}", sessionToken, timeStamp, secretKey));
                        if (!validationHash.Equals(clientHash, StringComparison.InvariantCultureIgnoreCase))
                        {
                            actionContext.Response = new JsonContent("Request could not be authenticated. Invalid hash encountered!", Status.Failed).ConvertToHttpResponseOK();
                            return;
                        }
                    }

                }

                if (!skipAuthorization)
                {
                    var deviceID = actionContext.Request.Headers.Any(m => m.Key == "DeviceID") ? actionContext.Request.Headers.GetValues("DeviceID").FirstOrDefault() : null;
                    if (deviceID == null)
                    {
                        actionContext.Response = new JsonContent("Request could not be authorized. Invalid deviceID encountered!", Status.Failed).ConvertToHttpResponseOK();
                        return;
                    }
                    if (UniqueDeviceId == null)
                    {
                        actionContext.Response = new JsonContent("Request could not be authorized. Invalid Unique Device ID encountered!", Status.Failed).ConvertToHttpResponseOK();
                        return;
                    }
                   


                    CreateNewSession SessionModel = new CreateNewSession();
                    var sessionId = new Guid(sessionToken);
                    SessionModel.UniqueDeviceId = UniqueDeviceId;
                    SessionModel.sessionId = sessionId;
                    SessionModel.DeviceToken = actionContext.Request.Headers.GetValues("DeviceID").FirstOrDefault();
                    SessionModel.DeviceType = Int32.Parse(actionContext.Request.Headers.GetValues("DeviceType").FirstOrDefault());

                    var deviceTypeID = actionContext.Request.Headers.Any(m => m.Key == "DeviceType") ? actionContext.Request.Headers.GetValues("DeviceType").FirstOrDefault() : "-1";
                    if (deviceTypeID == null)
                    {
                        actionContext.Response = new JsonContent("Request could not be authorized. Invalid Device type encountered!", Status.Failed).ConvertToHttpResponseOK();
                        return;
                    }
                    else 
                    {
                        int deviceType = Convert.ToInt32(deviceTypeID);
                        if ((int)RegisterVia.IPhone == deviceType) 
                        {
                            //chages on 22/10/2018 for iphone
                            //SessionModel.TokenVOIP = actionContext.Request.Headers.GetValues("TokenVOIP").FirstOrDefault();
                        }
                    }

                    

                    UserModel loginSession = _userManager.ValidateUserSession(SessionModel);
                    if (loginSession == null)
                    {
                        actionContext.Response = new JsonContent("Your session has expired.Please Log in again to continue.", Status.SessionExpired).ConvertToHttpResponseOK();
                        return;
                    }
                    else
                    {
                        if (deviceID == null)
                        {
                            actionContext.Response = new JsonContent("Request could not be authorized. Invalid deviceID encountered!", Status.Failed).ConvertToHttpResponseOK();
                            return;
                        }
                        else
                        {
                            loginSession.DeviceId = deviceID;
                        }


                        deviceTypeID = actionContext.Request.Headers.Any(m => m.Key == "DeviceType") ? actionContext.Request.Headers.GetValues("DeviceType").FirstOrDefault() : "-1";
                        int deviceType = Convert.ToInt32(deviceTypeID);
                        if ((int)RegisterVia.Android == deviceType || (int)RegisterVia.IPhone == deviceType)
                        {
                            loginSession.DeviceType = deviceType;
                        }
                        else
                        {
                            actionContext.Response = new JsonContent("Request could not be authorized. Invalid DeviceType encountered!", Status.Failed).ConvertToHttpResponseOK();
                            return;
                        }

                        if (loginSession == null)
                        {
                            actionContext.Response = new JsonContent("Your session has expired.Please Log in again to continue.", Status.SessionExpired).ConvertToHttpResponseOK();
                            return;
                        }
                        else
                        {
                            baseController.LOGGED_IN_USER = new UserModel
                            {
                                UserID = loginSession.UserID,
                                Email = loginSession.Email,
                                SessionId = sessionId,
                                //UsertypeId = loginSession.UsertypeId,
                                //SeekingFor = loginSession.SeekingFor,
                                //Birthday = loginSession.Birthday,
                                //Gender = loginSession.Gender,
                                //Location = loginSession.Location,
                                //userName = loginSession.userName,
                                //DateCreated = loginSession.DateCreated,
                                //DateModified = loginSession.DateModified,
                                //IsDeleted = loginSession.IsDeleted,
                                //lookingType = loginSession.lookingType,
                                //Sexuality = loginSession.Sexuality,
                                DeviceType = loginSession.DeviceType,
                                DeviceId = loginSession.DeviceId,
                                UniqueDeviceId = UniqueDeviceId,
                                //ProfileImage = loginSession.ProfileImage != null ? loginSession.ProfileImage : Config.DomainUrl + AppDefaults.ProfilePicDirectory + AppDefaults.DummyUserImage
                            };
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                System.IO.StreamWriter sw = null;
                try
                {
                    sw = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath("~/ErrorLog.txt"), true);
                    sw.WriteLine(ex.Message);
                    sw.WriteLine("http://jsonformat.com/");
                    sw.WriteLine(ex); sw.WriteLine(""); sw.WriteLine("");
                }
                catch { }
                finally { sw.Close(); }
            }

        }
    }

    /// <summary>
    /// methods marked with this will not be checked for authorization
    /// </summary>
    public class SkipAuthorization : Attribute { }


    /// <summary>
    /// methods marked with this will not be checked for authentication
    /// </summary>
    public class SkipAuthentication : Attribute { }
}