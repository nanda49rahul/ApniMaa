//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web;
//using ApniMaa.BLL.Common;;
//using ApniMaa.DAL;


//namespace ApniMaa.BLL.Models.Admin_Models
//{
//    public class DriverModel
//    {
//        public int FleetId { get; set; }
//        public int Id { get; set; }
//        [Required]
//        [StringLength(50)]
//        public string FirstName { get; set; }
       
//        [StringLength(50)]
//        public string LastName { get; set; }
        
//        public string PhoneNumber { get; set; }
//        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-??]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "Invalid Email")]
//        public string Email { get; set; }
       
//        [StringLength(50)]
//        public string LicenceNumber { get; set; }
//        [Required]
//        [StringLength(100)]
//        public string Address { get; set; }
//        [Required]
//        public int ProvinceId { get; set; }
//        [Required]
//        public int CityId { get; set; }
//        [Required]
//        public int CountryId { get; set; }
//        [StringLength(40)]
//        public string PostalCode { get; set; }
//        [Required]
//        public bool IsFaultAccidents { get; set; }
//        [Required]
//        public bool IsDriverUnderAge { get; set; }
//        [Required]
//        public bool IsMeetMVRCriteria { get; set; }
//        [Required]
//        public bool IsMeetExperienceCriteria { get; set; }
//        [Required]
//        public bool IsG2Driver { get; set; }
//        [Required]
//        public decimal MVR { get; set; }
//        [Required]
//        public decimal MVA { get; set; }

//        public bool IsThisDriver { get; set; }
//        public HttpPostedFileBase CompletedDriverApprovalApplication { get; set; }
//        public HttpPostedFileBase OriginalCommercialClaimsExperienceLetter { get; set; }
//        public HttpPostedFileBase OriginalPrivateClaimsExperienceLetter { get; set; }
//        public HttpPostedFileBase RecentOriginalMVRAbstract { get; set; }
//        public HttpPostedFileBase CurrentAutoplusGoldReport { get; set; }
//        public HttpPostedFileBase CopyofValidOntarioDriverLicense { get; set; }
//        public HttpPostedFileBase ValidTaxiDriverLicense { get; set; }


//        public int? AddedByApniMaa { get; set; }
//        public int? AddedByFleet { get; set; }
//        public bool IsActive { get; set; }
//        public int Status { get; set; }
//        public DateTime CreatedDate { get; set; }

//        public string CompletedDriverApprovalAppPath { get; set; }
//        public string OriginalPrivateClaimsExpLetterPath { get; set; }
//        public string OriginalCommercialClaimsExpLetterPath { get; set; }
//        public string RecentOriginalMVRAbstractPath { get; set; }
//        public string CurrentAutoplusGoldReportPath { get; set; }
//        public string CopyofValidOntarioDriverLicensePath { get; set; }
//        public string ValidTaxiDriverLicensePath { get; set; }
//        public int TempVehicleId { get; set; }

//        public string ProvinceName { get; set; }
//        public string CityName { get; set; }
//        public int UserId { get; set; }
//    }


//    public class DriverListingModel : DriverModel
//    {


//        public DriverListingModel() { }

//        public DriverListingModel(Driver model)
//        {
//            this.Id = model.Id;
//            this.FleetId = model.FleetId;
//            this.FirstName = model.User.FirstName;
//            this.LastName = model.User.LastName;
//            this.PhoneNumber = (model.User.UserContactDetails.Count > 0) ? model.User.UserContactDetails.FirstOrDefault().Phone : "";
//            this.Email = model.User.Email;

//            this.Address = (model.User.UserContactDetails.Count>0)?model.User.UserContactDetails.FirstOrDefault().StreetAddress:"";
//            this.ProvinceId = (model.User.UserContactDetails.Count>0)?model.User.UserContactDetails.FirstOrDefault().ProvinceId:0;
//            this.CityId =(model.User.UserContactDetails.Count>0)? model.User.UserContactDetails.FirstOrDefault().CityId:0;
//            this.CountryId = (model.User.UserContactDetails.Count>0)?model.User.UserContactDetails.FirstOrDefault().CountryId:0;
           
//            this.LicenceNumber = ( model.User.UserInformation!=null)?model.User.UserInformation.LicenceNumber:"";
//            this.ProvinceName = (model.User.UserContactDetails.Count > 0) ? model.User.UserContactDetails.FirstOrDefault().City.Province.Name : "";
//            this.PostalCode = (model.User.UserContactDetails.Count > 0) ? model.User.UserContactDetails.FirstOrDefault().PostalCode: "";
//            this.CityName = (model.User.UserContactDetails.Count > 0) ? model.User.UserContactDetails.FirstOrDefault().City.Name : "";
//            this.Address = (model.User.UserContactDetails.Count > 0) ? model.User.UserContactDetails.FirstOrDefault().StreetAddress : "";
//            this.ProvinceId = (model.User.UserContactDetails.Count > 0) ? model.User.UserContactDetails.FirstOrDefault().ProvinceId : 0;
//            this.CityId = (model.User.UserContactDetails.Count > 0) ? model.User.UserContactDetails.FirstOrDefault().CityId : 0;
//            this.CountryId = (model.User.UserContactDetails.Count > 0) ? model.User.UserContactDetails.FirstOrDefault().CountryId : 0;
//            this.IsFaultAccidents = model.IsFaultAccidents;
//            this.IsDriverUnderAge = model.IsDriverUnderAge;
//            this.IsMeetMVRCriteria = model.IsMeetMVRCriteria;
//            this.IsMeetExperienceCriteria = model.IsMeetExperienceCriteria;
//            this.IsG2Driver = model.IsG2Driver;
//            this.IsThisDriver = (model.CompletedDriverApprovalAppPath == null || model.CompletedDriverApprovalAppPath == "") ? false : true;
//            this.CompletedDriverApprovalAppPath = UtilitiesHelp.GetFilePath(AppFolderName.Driver, model.CompletedDriverApprovalAppPath, model.FleetId);
//            this.OriginalPrivateClaimsExpLetterPath = UtilitiesHelp.GetFilePath(AppFolderName.Driver, model.OriginalPrivateClaimsExpLetterPath, model.FleetId);
//            this.OriginalCommercialClaimsExpLetterPath = UtilitiesHelp.GetFilePath(AppFolderName.Driver, model.OriginalCommercialClaimsExpLetterPath, model.FleetId);
//            this.RecentOriginalMVRAbstractPath = UtilitiesHelp.GetFilePath(AppFolderName.Driver, model.RecentOriginalMVRAbstractPath, model.FleetId);
//            this.CurrentAutoplusGoldReportPath = UtilitiesHelp.GetFilePath(AppFolderName.Driver, model.CurrentAutoplusGoldReportPath, model.FleetId);
//            this.CopyofValidOntarioDriverLicensePath = UtilitiesHelp.GetFilePath(AppFolderName.Driver, model.CopyofValidOntarioDriverLicensePath, model.FleetId);
//            this.ValidTaxiDriverLicensePath = UtilitiesHelp.GetFilePath(AppFolderName.Driver, model.ValidTaxiDriverLicensePath, model.FleetId);
//            this.Status = model.Status;
//            this.CreatedDate = model.CreatedDate;
//            this.UserId = model.User.UserId;
//            this.MVR = model.MVR;
//            this.MVA = model.MVA;
//        }
//        public DriverListingModel(User model)
//        {
//            //this.Id = model.Id;
//            this.FirstName = model.FirstName;
//            this.LastName = model.LastName;
//            this.PhoneNumber = (model.UserContactDetails.Count > 0) ? model.UserContactDetails.FirstOrDefault().Phone : "";
//            this.Email = model.Email;

//            this.Address = (model.UserContactDetails.Count > 0) ? model.UserContactDetails.FirstOrDefault().StreetAddress : "";
//            this.ProvinceId = (model.UserContactDetails.Count > 0) ? model.UserContactDetails.FirstOrDefault().ProvinceId : 0;
//            this.CityId = (model.UserContactDetails.Count > 0) ? model.UserContactDetails.FirstOrDefault().CityId : 0;
//            this.CountryId = (model.UserContactDetails.Count > 0) ? model.UserContactDetails.FirstOrDefault().CountryId : 0;

//            this.LicenceNumber = (model.UserInformation != null) ? model.UserInformation.LicenceNumber : "";
//            this.ProvinceName = (model.UserContactDetails.Count > 0) ? model.UserContactDetails.FirstOrDefault().City.Province.Name : "";
//            this.CityName = (model.UserContactDetails.Count > 0) ? model.UserContactDetails.FirstOrDefault().City.Name : "";
//            this.Address = (model.UserContactDetails.Count > 0) ? model.UserContactDetails.FirstOrDefault().StreetAddress : "";
//            this.ProvinceId = (model.UserContactDetails.Count > 0) ? model.UserContactDetails.FirstOrDefault().ProvinceId : 0;
//            this.CityId = (model.UserContactDetails.Count > 0) ? model.UserContactDetails.FirstOrDefault().CityId : 0;
//            this.CountryId = (model.UserContactDetails.Count > 0) ? model.UserContactDetails.FirstOrDefault().CountryId : 0;
//            this.IsActive = model.IsActive;
//            this.CreatedDate = model.CreatedDate;
//            this.UserId = model.UserId;
//        }
//    }

//    public class DriverSearchListingModel 
//    {
//        public int Id { get; set; }
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public string LicenseNumber { get; set; }
//    }

//    public class ApprovalRejectionModel
//    {
//        public int Id { get; set; }
//        public bool IsApproved { get; set; }
//        public string ReasonNote { get; set; }
//        public bool IsFaultAccidents { get; set; }
//        public bool IsDriverUnderAge { get; set; }
//        public bool IsMeetMVRCriteria { get; set; }
//        public bool IsMeetExperienceCriteria { get; set; }
//        public bool IsG2Driver { get; set; }
//    }
//}
