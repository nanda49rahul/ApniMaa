
using ApniMaa.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApniMaa.BLL.Models
{
    public class LoginModal
    {
        [Required(ErrorMessage = "Required"), DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Password { get; set; }

        public int UserType { get; set; }
    }

    public class UserInfo  : IUserInfo
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int UserType { get; set; }
        public int FleetId { get; set; }
        public string FleetName { get; set; }
        public string ProfileImage { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool IsProspect { get; set; }
        public bool IsRunOff { get; set; }
    }

    public class ForgotPasswordModel
    {
        [Required(ErrorMessage = "Required"), DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }
    }

    public class GenerateNewPasswordModel
    {
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password must be greaterr than 6 characters")]
        public string NewPassword { get; set; }
        [Compare("NewPassword", ErrorMessage = "Password and Confirm Password does not match")]
        public string NewConfirmPassword { get; set; }
        public string token { get; set; }
        public ActionStatus Status { get; set; }
        public string UserMail { get; set; }
    }
}
