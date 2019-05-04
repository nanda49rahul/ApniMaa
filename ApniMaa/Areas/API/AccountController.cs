using ApniMaa.Attributes;
using ApniMaa.BLL.Interfaces;
using ApniMaa.BLL.Models;
using ApniMaa.Framework.Api;
using ApniMaa.Framework.Api.Helpers;
using System;
using System.Net;
using System.Net.Http;
using System.Linq;
using System.Web.Http;
using ApniMaa.BLL.Managers;

namespace ApniMaa.Areas.API
{
    public class AccountController : BaseAPIController
    {
        IUserManager _userManager;
        //IPushNotificationManager _pushNotificationManager;
        //IAdminManager _adminManager;
        public AccountController(IUserManager userManager)
        {
            _userManager = userManager;
            //  _pushNotificationManager = pushNotificationManager;
          
        }

        ///// <summary>
        ///// API method for login
        ///// </summary>
        ///// <param name="model">Username/Email and Password</param>
        ///// <returns> If Valid -> Authentication token And user details</returns>


        [SkipAuthorization]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage GenerateGuestId()
        {
           
            var result = _userManager.GenrateGuestId();
            if (result.Status == ActionStatus.Successfull)
            {
                return CreateResponseSuccess(result.Message,result.Object);
            }
            else
            {
                return CreateResponseError(result.Message);
            }
        }

        


        [SkipAuthorization]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage PhoneLogin([FromBody] LoginModel model)
        {
            if (model == null)
                throw new HttpResponseException(new HttpResponseMessage() { StatusCode = HttpStatusCode.Unauthorized, Content = new StringContent("Please provide the login credentials.") });
            var result = _userManager.PhoneLogin(model);
            if(result.Status==ActionStatus.Successfull)
            {
                return CreateResponseSuccess(result.Message);
            }
            else
            {
                return CreateResponseError(result.Message);
            }
        }
        [SkipAuthorization]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage OTPLogin([FromBody] LoginModel model)
        {
            if (model == null)
                throw new HttpResponseException(new HttpResponseMessage() { StatusCode = HttpStatusCode.Unauthorized, Content = new StringContent("Please provide the login credentials.") });
            var result = _userManager.OTPLogin(model);
            if (result != null)
            {
                if (result.Object.IsDeleted == true)
                {
                    return new JsonContent("Your Account has been deleted temporarily", Status.DeletedUserCode, result.Object).ConvertToHttpResponseOK();
                }
                else
                {
                    var token = CreateNewSession(result.Object.UserID);
                    result.Object.SessionId = Guid.Parse(token);
                    return new JsonContent(Messages.LoginSuccess, Status.Success, new { User = result.Object }).ConvertToHttpResponseOK();
                }
            }
            else
            { return new JsonContent(Messages.INCORRECT, Status.Failed, result).ConvertToHttpResponseOK(); }
        }

        /// <summary>
        /// API method for register
        /// </summary>
        /// <param name="model">Username/Email and Password</param>
        /// <returns> If Valid -> Authentication token And user details</returns>
        [SkipAuthorization]
        public HttpResponseMessage RegisterUser([FromBody] RegisterModel model)
        {
            if (model == null)
                throw new HttpResponseException(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = new StringContent("Please provide the required fields.")
                });

            var result = _userManager.RegisterUser(model);
            if (result.Status == ActionStatus.Successfull)
            {
                var token = CreateNewSession(result.Object.UserID);
                result.Object.SessionId = Guid.Parse(token);
                return new JsonContent(Messages.RegisterSuccess, Status.Success, new { user = result.Object }).ConvertToHttpResponseOK();
            }
            else
            {
                return new JsonContent("Error While SignUp", Status.Failed, result).ConvertToHttpResponseOK();
            }
        }

        [SkipAuthorization]
        public HttpResponseMessage VerifyUser([FromBody] OTPModel model)
        {
            if (model == null)
                throw new HttpResponseException(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = new StringContent("Please provide the required fields.")
                });

            var result = _userManager.VeifyOTP(model);
            if (result.Status==ActionStatus.Successfull)
            {
                var token = CreateNewSession(result.Object.UserID);
                result.Object.SessionId = Guid.Parse(token);
                return new JsonContent(result.Message, Status.Success, new { user = result.Object }).ConvertToHttpResponseOK();
            }
            else
            {
                return new JsonContent("Error While SignUp", Status.Failed, result).ConvertToHttpResponseOK();
            }
        }

        
        /// <summary>
        /// create new session when user trying to login
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string CreateNewSession(int userId)
        {
            CreateNewSession SessionModel = new CreateNewSession();
            SessionModel.UserID = userId;
            SessionModel.UniqueDeviceId = Request.Headers.GetValues("UniqueDeviceId").FirstOrDefault();
            SessionModel.DeviceToken = Request.Headers.GetValues("DeviceID").FirstOrDefault();
            SessionModel.DeviceType = Int32.Parse(Request.Headers.GetValues("DeviceType").FirstOrDefault());
            var token = _userManager.CreateSession(SessionModel);
            return token;
        }

        [SkipAuthorization]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage UpdateUserProfile(UserModel model)
        {

            var result = _userManager.UpdateUserProfile(model);
            if (result.Status == ActionStatus.Successfull)
            {

                return new JsonContent(result.Message, Status.Success).ConvertToHttpResponseOK();
            }
            else
            {
                return new JsonContent(result.Message, Status.Failed, result).ConvertToHttpResponseOK();
            }
        }

        [SkipAuthorization]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetUserProfile(int Id)
        {

            var result = _userManager.GetUserProfile(Id);
            if (result.Status == ActionStatus.Successfull)
            {

                return new JsonContent(result.Message, Status.Success, new { user = result.Object }).ConvertToHttpResponseOK();
            }
            else
            {
                return new JsonContent(result.Message, Status.Failed, result).ConvertToHttpResponseOK();
            }
        }

       
        ///// <summary>
        ///// Delete user account
        ///// </summary>
        ///// <param name="userId"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public HttpResponseMessage DeleteUserAccount(DeleteUserAccount model)
        //{
        //    if (model.userId <= 0)
        //        throw new HttpResponseException(new HttpResponseMessage() { StatusCode = HttpStatusCode.Unauthorized, Content = new StringContent("Please Provide User IDs") });

        //    var found = _userManager.DeleteUserAccount(model.userId);
        //    if (found != null)
        //    {
        //        return new JsonContent(found, Status.Success, null).ConvertToHttpResponseOK();
        //    }
        //    else
        //    {
        //        return new JsonContent("User not found", Status.Failed).ConvertToHttpResponseOK();
        //    }
        //    //return found;
        //}

        ///// <summary>
        ///// Add user feedback
        ///// </summary>
        ///// <param name="userId"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public HttpResponseMessage AddFeedback(AddFeedbackModel model)
        //{
        //    if (model == null)
        //        throw new HttpResponseException(new HttpResponseMessage() { StatusCode = HttpStatusCode.Unauthorized, Content = new StringContent("Please Provide Required Data") });

        //    var found = _userManager.AddFeedback(model.userId, model.FeedbackMessage);

        //    return new JsonContent(found, Status.Success, null).ConvertToHttpResponseOK();
        //    //return found;
        //}


        ///// <summary>
        ///// API method for Sign Up
        ///// </summary>
        //[SkipAuthorization, HttpPost]
        //public HttpResponseMessage SignUp([FromBody] followupApiSignUpModel model)
        //{
        //    if (model == null)
        //        throw new HttpResponseException(new HttpResponseMessage() { StatusCode = HttpStatusCode.Unauthorized, Content = new StringContent("Please Fill the Form Properly.") });
        //    if (model.Email != null && model.FacebookId == null && model.GoogleId == null)
        //    {
        //        ISEmailExist verfiymodel = new ISEmailExist();
        //        verfiymodel.Email = model.Email;
        //        var found = _userManager.ISEmailExist(verfiymodel);
        //        if (found != null) return new JsonContent("Email Account Already Exist", Status.Failed, null).ConvertToHttpResponseOK();
        //    }
        //    ////CAN GET IT SIGN UP 
        //    if (model.FacebookId == null && model.GoogleId == null)
        //    {
        //        var result = _userManager.SignUp(model); // UserManager hit 
        //        if (result.Object != null)
        //        {
        //            var token = CreateNewSession(result.Object.UserId);
        //            result.Object.SessionId = Guid.Parse(token);
        //            return new JsonContent("SignUp Successfully", Status.Success, new { User = result.Object }).ConvertToHttpResponseOK();
        //        }
        //        else { return new JsonContent(result.Message, Status.Failed, result).ConvertToHttpResponseOK(); }
        //    }
        //    //// FaceBook SIGN UP FUNCTIONALITY
        //    if (model == null) { throw new HttpResponseException(new HttpResponseMessage() { StatusCode = HttpStatusCode.UnsupportedMediaType, Content = new StringContent("PLease Provide Proper details") }); }

        //    if (model.FacebookId != null && model.GoogleId == null)
        //    {
        //        var result = _userManager.SignUpLoginFacebook(model);
        //        if (result != null)
        //        {
        //            var token = CreateNewSession(result.Object.UserId);// UserManager hit
        //            result.Object.SessionId = Guid.Parse(token);
        //            return new JsonContent(result.Message, Status.Success, new { User = result.Object }).ConvertToHttpResponseOK();
        //        }
        //        else { return new JsonContent("Error while Facebook SignUp", Status.Failed).ConvertToHttpResponseOK(); }
        //    }

        //    if (model.FacebookId == null && model.GoogleId != null)
        //    {
        //        var result = _userManager.SignUpLoginGoogle(model);
        //        if (result != null)
        //        {
        //            var token = CreateNewSession(result.Object.UserId);// UserManager hit
        //            result.Object.SessionId = Guid.Parse(token);
        //            return new JsonContent(result.Message, Status.Success, new { User = result.Object }).ConvertToHttpResponseOK();
        //        }
        //        else { return new JsonContent("Error while Google SignUp", Status.Failed).ConvertToHttpResponseOK(); }
        //    }
        //    return new JsonContent("Error while SignUp", Status.Failed).ConvertToHttpResponseOK();
        //}

        ///// <summary>
        ///// API Method To Logout to user
        ///// </summary>
        //[HttpPost]
        //public HttpResponseMessage Logout()
        //{
        //    string uniqueDeviceId = Request.Headers.GetValues("UniqueDeviceId").FirstOrDefault();
        //    var result = _userManager.Logout(LOGGED_IN_USER.UserId, uniqueDeviceId);
        //    if (result != null)
        //    { return new JsonContent("Logout Successfully", Status.Success).ConvertToHttpResponseOK(); }
        //    else { return new JsonContent("Error while Logout the User", Status.Failed).ConvertToHttpResponseOK(); }
        //}


        ///// <summary>
        ///// Get User Profile Details
        ///// </summary>
        //[HttpGet]
        //public HttpResponseMessage GetUserProfile(int UserId)
        //{
        //    //if (userId == 0)
        //    //    throw new HttpResponseException(new HttpResponseMessage() { StatusCode = HttpStatusCode.Unauthorized, Content = new StringContent("Please Provide user ID") });
        //    var result = _userManager.GetUserProfileDetails(UserId);

        //    if (result != null)
        //    {
        //        return new JsonContent("Profile Details", Status.Success, new { User = result }).ConvertToHttpResponseOK();
        //    }
        //    return new JsonContent("Error while Getting profile Details", Status.Failed).ConvertToHttpResponseOK();
        //}

        ///// <summary>
        ///// Update User Location
        ///// </summary>
        //[HttpPost]
        //public HttpResponseMessage UpdateUserLocation([FromBody] UpdateUserLocationModel model)
        //{
        //    if (model == null)
        //        throw new HttpResponseException(new HttpResponseMessage() { StatusCode = HttpStatusCode.Unauthorized, Content = new StringContent("Please Provide user ID") });

        //    var result = _userManager.UpdateLocation(model.userId, model.Lat, model.Long, model.address);

        //    if (result.Status == ActionStatus.Successfull)
        //    {
        //        return new JsonContent(result.Message, Status.Success, result.Results).ConvertToHttpResponseOK();
        //    }
        //    return new JsonContent(result.Message, Status.Failed).ConvertToHttpResponseOK();
        //}


        ///// <summary>
        ///// Update User Settings
        ///// </summary>
        //[HttpPost]
        //public HttpResponseMessage UpdateUserSettings([FromBody] UserSettingModel model)
        //{
        //    if (model == null)
        //        throw new HttpResponseException(new HttpResponseMessage() { StatusCode = HttpStatusCode.Unauthorized, Content = new StringContent("Please Provide user ID") });

        //    var validationResponse = Utilities.FormValidation(model);

        //    if (!validationResponse.IsValidModel)
        //        return new JsonContent("Validation Error", Status.Failed, validationResponse.ValidationResultList).ConvertToHttpResponseOK();

        //    var result = _userManager.UpdateUserSettings(model);

        //    if (result != null)
        //    {
        //        return new JsonContent(result.Message, Status.Success, result.Results).ConvertToHttpResponseOK();
        //    }
        //    return new JsonContent("Error while Updating Location", Status.Failed).ConvertToHttpResponseOK();
        //}


        ///// <summary>
        ///// Get User Settings
        ///// </summary>
        //[HttpPost]
        //public HttpResponseMessage GetUserSettings()
        //{
        //    var result = _userManager.GetUserSettings(LOGGED_IN_USER.UserId);

        //    if (result != null)
        //    {
        //        return new JsonContent(result.Message, Status.Success, result.Object).ConvertToHttpResponseOK();
        //    }
        //    return new JsonContent("Error while Getting User Settings", Status.Failed).ConvertToHttpResponseOK();
        //}

        ///// <summary>
        ///// Edit User Profile
        ///// </summary>
        //[HttpPost]
        //public HttpResponseMessage EditUserProfile(EditUserProfileModel Data)
        //{
        //    var result = _userManager.EditUserProfile(Data);

        //    if (result != null)
        //    {
        //        return new JsonContent(result.Message, Status.Success, result.Results).ConvertToHttpResponseOK();
        //    }
        //    return new JsonContent("Error while Updating Profile", Status.Failed).ConvertToHttpResponseOK();
        //}

        ///// <summary>
        /////  Save Quickblox Details
        ///// </summary>
        //[HttpPost]
        //public HttpResponseMessage UpdateProfilePics()
        //{
        //    var httprequest = HttpContext.Current.Request;
        //    var form = httprequest.Form;

        //    UpdateProfileImageModel model = new UpdateProfileImageModel();

        //    model.ImageType = form["ImageType"].ToString();
        //    if (form["UserID"] != null)
        //    {
        //        model.UserID = Convert.ToInt32(form["UserID"]);
        //    }

        //    if (httprequest.Files.Count > 0)
        //    {
        //        for (int i = 0; i < httprequest.Files.Count; i++)
        //        {
        //            var postedfile = httprequest.Files[i];
        //            string guid = Guid.NewGuid().ToString();
        //            var filepath = HttpContext.Current.Server.MapPath("~/images/UsersUpload/" + guid + postedfile.FileName);
        //            postedfile.SaveAs(filepath);
        //            model.ImageURL = guid + postedfile.FileName;
        //        }
        //    }
        //    var validationresponse = Utilities.FormValidation(model);
        //    if (!validationresponse.IsValidModel)
        //        return new JsonContent("Validation Error", Status.Failed, validationresponse.ValidationResultList).ConvertToHttpResponseOK();

        //    var result = _userManager.UpdateProfilePics(model);
        //    if (result != null)
        //    {
        //        return new JsonContent(result.Message, Status.Success, result.Results).ConvertToHttpResponseOK();
        //    }
        //    return new JsonContent("Error while Updating Profile", Status.Failed).ConvertToHttpResponseOK();
        //}


        ///// <summary>
        ///// Save Quickblox Details
        ///// </summary>
        //[HttpPost]
        //public HttpResponseMessage SaveQBDetails([FromBody] AddQuickBloxModel model)
        //{
        //    if (model == null)
        //        throw new HttpResponseException(new HttpResponseMessage() { StatusCode = HttpStatusCode.Unauthorized, Content = new StringContent("Please Provide user ID") });

        //    var result = _userManager.SaveQBDetails(model);

        //    if (result.Status == ActionStatus.Successfull)
        //    {
        //        return new JsonContent(result.Message, Status.Success, result.Results).ConvertToHttpResponseOK();
        //    }
        //    return new JsonContent(result.Message, Status.Failed).ConvertToHttpResponseOK();
        //}

    }
}