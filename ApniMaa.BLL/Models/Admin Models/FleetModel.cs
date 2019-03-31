//using ApniMaa.BLL.Common;;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;
//using ApniMaa.DAL;
//using System.ComponentModel.DataAnnotations;

//namespace ApniMaa.BLL.Models
//{
//    public class FleetModel
//    {

//        public int Id { get; set; }
//        public string FleetName { get; set; }
//        public string ShortName { get; set; }
//        public string InsuranceCompany { get; set; }
//        public string ClaimNumber { get; set; }
//        public string RIM { get; set; }
//        public string StreetAddress { get; set; }
//        public int ProvinceID { get; set; }
//        public int CityID { get; set; }
//        public int CountryID { get; set; }
//        public string PostalCode { get; set; }
//        public string PrimaryContact { get; set; }
//        public string Phone { get; set; }
//        public string Email { get; set; }
//        public bool IsActive { get; set; }
//        public DateTime CreatedDate { get; set; }
//        public DateTime UpdatedDate { get; set; }
//        public string CityName { get; set; }
//        public List<AuditLogModel> AuditList { get; set; }
//        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$", ErrorMessage = "Password must be of minimum 8 characters including one upper case, number and special character.")]
//        public string Password { get; set; }
//        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password and Confirm Password does not match")]
//        public string ConfirmPassword { get; set; }

//        public FleetModel() { }

//        public FleetModel(Fleet obj)
//        {
//            this.Id = obj.Id;
//            this.FleetName = obj.FleetName;
//            this.ShortName = obj.ShortName;
//            this.InsuranceCompany = obj.InsuranceCompany;
//            this.ClaimNumber = obj.ClaimNumber;
//            this.RIM = obj.RIM;
//            this.StreetAddress = obj.StreetAddress;
//            this.ProvinceID = obj.ProvinceID;
//            this.CityID = obj.CityID;
//            this.CountryID = obj.CountryID;
//            this.PostalCode = obj.PostalCode;
//            this.PrimaryContact = obj.PrimaryContact;
//            this.Phone = obj.Phone;
//            this.Email = obj.Email;
//            this.IsActive = obj.IsActive;
//            this.CreatedDate = obj.CreatedDate;
//            this.UpdatedDate = obj.UpdatedDate;
//            this.CityName = obj.City.Name;
//        }
//    }

//    public class FleetDocumentModel
//    {
//        public int Id { get; set; }
//        public int FleetID { get; set; }
//        public int UserID { get; set; }
//        public string FileName { get; set; }
//        public string OriginalName { get; set; }
//        public DateTime AddedOn { get; set; }

//        public FleetDocumentModel() { }

//        public FleetDocumentModel(FleetDocument obj)
//        {
//            this.AddedOn = obj.AddedOn;
//            this.FileName = obj.FileName;
//            this.FleetID = obj.FleetID ?? 0;
//            this.OriginalName = obj.OriginalName;
//            this.UserID = obj.AddedBy;
//        }

        

//    }
  
//}
