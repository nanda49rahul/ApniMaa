using OzzieLeads.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OzzieLeads.BLL.Models
{
    /// <summary>
    /// Login Model this will be  used to login in the application
    /// </summary>
    public class LoginModal
    {
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-??]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "Invalid Email")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Password { get; set; }

        public bool IsPersistent { get; set; }
    }

    /// <summary>
    /// UserListing Model : This will be used to List all the users in Admin panel
    /// </summary>
    public class UserListingModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; }

        public UserListingModel()
        {

        }

        public UserListingModel(User userObj)
        {
            this.FirstName = userObj.FirstName;
            //this.LastName = userObj.LastName;
            this.Email = userObj.Email;
            this.UserId = userObj.UserID;
            this.CreatedOn = userObj.CreatedAt;
        }

    }

    public class UserModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-??]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        public string phoneNo { get; set; }
        public string DeviceId { get; set; }
        public Guid SessionId { get; set; }
        public int DeviceType { get; set; }
        public string UniqueDeviceId { get; set; }

        public UserModel() { }
        public UserModel(User userObj)
        {
            this.UserId = userObj.UserID;
            this.Name = userObj.FirstName;
            //this.phoneNo = userObj.PhoneNo;
        }

        public UserModel(Guid sessionId, User obj)
            : this(obj)
        {
            SessionId = sessionId;
        }

    }
    public class AddUserModel : UserModel
    {
        [Required(ErrorMessage = "Required")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password should be minimum of 6 and maximum of 20 characters.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and Confirm Password does not match")]
        public string ConfirmPassword { get; set; }

        public AddUserModel()
        {

        }
        
    }

    public class ResetPasswordOTPModel
    {

        [Required]
        public string Email { get; set; }
        [Required(ErrorMessage = "OTP is Required")]
        public int OTP { get; set; }
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password should be minimum of 6 and maximum of 20 characters.")]
        [Required(ErrorMessage = "Password is Required")]
        public string NewPassword { get; set; }
    }
    public class ResetPasswordModel
    {
        //public ResetPasswordModel();
        [Required(ErrorMessage = "Required")]
        [Compare("NewPassword", ErrorMessage = "Password and Confirm Password does not match")]
        public string ConfirmNewPassword { get; set; }
        [RegularExpression("^(?=.{6,}$)(?=.*[A-Z])(?=.*[0-9]).*", ErrorMessage = "Password must be 6 characters including 1 uppercase letter and 1 numeric value.")]
        [Required(ErrorMessage = "Required")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password should be minimum of 6 and maximum of 20 characters.")]
        public string NewPassword { get; set; }
        public string Token { get; set; }
        public int UserId { get; set; }
    }
    public class ForgotPasswordModel
    {
        [EmailAddress(ErrorMessage = "Invaid Email Address")]
        [Required]
        public string UserName { get; set; }
    }
    public class ForgotPasswordRequestModel
    {
        public int PasswordRequestId { get; set; }
        public int UserId { get; set; }
        public string OTPCode { get; set; }
        public bool IsActive { get; set; }
        public DateTime RequestedDate { get; set; }
    }

    public class PermissonAndDetailModel
    {
        public UserDetails UserDetails { get; set; }
        public IList<ModulesModel> ModulesModelList { get; set; }
    }

    public class CreateNewSession
    {
        public int UserID { get; set; }
        public string UniqueDeviceId { get; set; }
        public string DeviceToken { get; set; }
        public int DeviceType { get; set; }
        public string Session { get; set; }
        public Guid sessionId { get; set; }
        public string TokenVOIP { get; set; }
    }
}