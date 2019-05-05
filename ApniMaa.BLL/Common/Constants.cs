using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;

namespace ApniMaa.BLL.Models
{
    public static class Cookies
    {
        //replace xyz with required name as per your project
        public const string AdminAuthorizationCookie = "xyzAuthorize";
        public const string AuthorizationCookie = "xyzFirmAuthorize";

    }
    public static class SelectedAdminTab
    {
        public const string Users = "Users";
        public const string Category = "Category";
        public const string Dashboard = "Dashboard";
        public const string Dish = "Dish";
        public const string Order = "Order";
        public const string CMSManager = "CMSManager";
        public const string Templates = "Templates";
      
    }
    public static class AppDefaults
    {
        public const Int32 PageSize = 10;
        public const string DateTimeFormat = "MM/dd/yyyy";
    
    }
    public static class ValidateGoogleCaptcha
    {
        public static CaptchaResponse ValidateCaptcha(string response)
        { 
            string secret = WebConfigurationManager.AppSettings["reCaptchaSecretKey"];

            var client = new WebClient();
            var reply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));

            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);

            return captchaResponse;
        }
    }

    public static class AppFolderName 
    {
        public const string Driver = "Driver";
        public const string Certificate = "Certificate";
        public const string PinkSlip = "PinkSlip";
        public const string BrokerCertificate = "BrokerCertificate";
        public const string CancellationCertificate = "CancellationCertificate";
        public const string Template = "Template";
        public const string DishImage = "DishImage";
    }
    public static class Messages
    {
        public const string OTP_SENT = "A security code has been sent on your registered email address.";
        public const string PASSWORD_RESET_LINK = "A password reset link has been sent to your registered email address.";
        public const string NOT_IMPLEMENTED = "Not implemented yet";
        public const string INCORRECT = "Incorrect username or password";
        public const string EMPTY_MODEL = "Model is Empty";
        public const string VERIFY_EMAIL = "A link has been sent to your email for verification. If you haven’t received any, check your junk ";
        public const string INVALID_IDENTITY = "Invalid indentity or client machine.";
        public const string INVALID_TOKEN = "Invalid token.";
        public const string MISSING_TOKEN = "Request is missing authorization token.";
        public const string USER_NOT_EXISTS = "User does not exist";
        public const string ALREADY_EXISTS = "Email ID already Exist";
        public const string PASSWORD_CHANGED = "Password changed successfully";
        public const string PASSWORD_MISMATCH = "Old Password not matched";
        public const string PROFILE_UPDATED = "Profile Updated";
        public const string ISE = "Internal Server Error";
        public const string FEEDBACK_SUBMITTED = "Your feedback has been submitted";
        public const string INQUIRY_SUBMITTED = "Your enquiry has been submitted";
        public const string NOT_MULTIPART = "Unsupported Media Type";
        public const string IMAGE_UPDATED = "Profile Image Updated";
        public const string NO_IMAGE = "No image received";
        public const string AUTH_FAIL = "Authentication failed for the user";
        public const string NOT_AVAIL = "Not Available";
        public const string INVALID_SESSION = "Either session has been expired or is invalid";
        public const string OTP_NOT_VALID = "Security code is not valid.";
        public const string OTP_VALID = "Security code is valid.";
        public const string NO_PADDY_MANDIES = "No paddy mandies exist or are not active.";
        public const string PADDY_MANDI_ADDED = "Paddy mandi name has been successfully added.";
        public const string PADDY_MANDI_EXISTS = "Paddy mandi with the same name already exists.";
        public static string SAVE_PROFILE_OK = "Profile successfully updated.";
        public static string SAVE_PROFILE_FAIL = "Something went wrong while updating profile.";
        public static string LoginSuccess = "Login Successfully";
        public static string RegisterSuccess = "Registered Successfully";
    }
}