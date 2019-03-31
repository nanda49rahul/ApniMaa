using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApniMaa.BLL.Models
{
    /// <summary>
    /// Change Password model
    /// </summary>
    public class ChangePassword
    {
        [Required(ErrorMessage = "Required")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password should be minimum of 6 and maximum of 20 characters.")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password should be minimum of 6 and maximum of 20 characters.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Password and Confirm Password does not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }

    public class VerificationModel
    {
        public int Status { get; set; }
        public int UserType { get; set; }
    }

    /// <summary>
    /// This model is used to Reset new Password 
    /// </summary>
    public class ResetPassword : VerificationModel
    {
        [Required(ErrorMessage = "Required")]
        public string Code { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "* Required")]
        [Compare("NewPassword", ErrorMessage = "New Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class VerifyUserByTokenModel
    {
        public int TokenStatus { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int UserType { get; set; }
    }
}
