//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ApniMaa.DAL;

//namespace ApniMaa.BLL.Models.Frontend_Models
//{
//    public class EmployeeModel
//    {
//        public int EmployeeId { get; set; }
//        public int FKUserId { get; set; }
//        public int FleetId { get; set; }
//        [Required]
//        [StringLength(50)]
//        public string FirstName { get; set; }
//        [Required]
//        [StringLength(50)]
//        public string LastName { get; set; }
//        [Required]
//        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-??]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "Invalid Email")]
//        public string Email { get; set; }
//        [Required]
//        public string Phone { get; set; }
//        [Required]
//        [StringLength(150)]
//        public string StreetAddress { get; set; }
//        [Required]
//        public int CountryId { get; set; }
//        [Required]
//        public int ProvinceId { get; set; }
//        [Required]
//        public int CityId { get; set; }
//        [Required]
//        [StringLength(50)]
//        public string PostalCode { get; set; }
//        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$", ErrorMessage = "Password must be of minimum 8 characters including one upper case, number and special character.")]
//        public string Password { get; set; }
//        [Compare("Password", ErrorMessage = "Password and Confirm Password does not match")]
//        public string ConfirmPassword { get; set; }
//    }

//    public class EmployeeListingModel : EmployeeModel
//    {
//        public bool IsActive { get; set; }

//        public EmployeeListingModel() { }

//        public EmployeeListingModel(User  model) 
//        {
//            if (model.FleetEmployees.Count > 0)
//            {
//                this.EmployeeId = model.FleetEmployees.FirstOrDefault().FleetEmployeeId;
//            }
//            this.FKUserId = model.UserId;
//            this.FirstName = model.FirstName;
//            this.LastName = model.LastName;
//            this.Email = model.Email;

//            if (model.UserContactDetails != null)
//            {
//                if (model.UserContactDetails.Count > 0)
//                {
//                    this.Phone = model.UserContactDetails.FirstOrDefault().Phone;
//                    this.StreetAddress = model.UserContactDetails.FirstOrDefault().StreetAddress;
//                    this.CountryId = model.UserContactDetails.FirstOrDefault().CountryId;
//                    this.ProvinceId = model.UserContactDetails.FirstOrDefault().ProvinceId;
//                    this.CityId = model.UserContactDetails.FirstOrDefault().CityId;
//                    this.PostalCode = model.UserContactDetails.FirstOrDefault().PostalCode;
//                }
//            }

//            this.IsActive = model.IsActive;
//        }
//    }
//}
