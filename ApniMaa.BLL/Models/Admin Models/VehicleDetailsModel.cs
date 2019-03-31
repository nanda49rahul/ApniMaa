//using ApniMaa.BLL.Common;;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;
//using ApniMaa.DAL;

//namespace ApniMaa.BLL.Models
//{
//    public class VehicleDetailsModel
//    {

//        public int Id { get; set; }
//        public int FleetId { get; set; }
//        public string ApniMaaRefrenceID { get; set; }
//        public int VehicleType { get; set; }
//        public string VIM { get; set; }
//        public string RIM { get; set; }
//        public string PlateNumber { get; set; }
//        public int ProvinceID { get; set; }
//        public int CityID { get; set; }
//        public DateTime CreatedDate { get; set; }
//        public DateTime LastModified { get; set; }
//        public bool IsLeased { get; set; }
//        public bool IsFinanced { get; set; }

//        public int? LesseId { get; set; }
//        public int? LessorId { get; set; }
//        public int? LeinholderId { get; set; }

        

//        public int? Coverage_DCPD { get; set; }
//        public int? Coverage_COLL { get; set; }
//        public int? Coverage_COMP { get; set; }



//        public string Noc { get; set; }

//        public int? AddedByApniMaa { get; set; }
//        public int? AddedByFleet { get; set; }

//        public string ProvinceName { get; set; }
//        public string FleetName { get; set; }
//        public string Municipality { get; set; }

//        public HttpPostedFileBase NocFile { get; set; }
//        public string NocPath { get; set; }

       
       
//        public bool IsLessorDriver { get; set; }
//        public bool IsLesseDriver { get; set; }
        
//        public System.DateTime? EffectiveDate { get; set; }
//        public System.DateTime? Expiry { get; set; }
//        public int ComissionId { get; set; }
        
//        public string Make { get; set; }
//        public string Manufacturer_Name { get; set; }
//        public string Model { get; set; }
//        public string Model_Year { get; set; }
//        public string Series { get; set; }
//        public string Vehicle_Type { get; set; }
//        public string Body_Class { get; set; }
//        public string Steering_Location { get; set; }
//        public string Drive_Type { get; set; }
//        public bool isVimVerified { get; set; }

//        public int? Driver1Id { get; set; }
        

//        public int? Driver2Id { get; set; }
        

//        public int? Driver3Id { get; set; }
        

//        public int? Driver4Id { get; set; }

//        public string Driver1FirstName { get; set; }
//        public string Driver1LastName { get; set; }
//        public string Driver1Email { get; set; }
//        public string Driver1License { get; set; }

        
//        public string Driver2FirstName { get; set; }
//        public string Driver2LastName { get; set; }
//        public string Driver2Email { get; set; }
//        public string Driver2License { get; set; }

        
//        public string Driver3FirstName { get; set; }
//        public string Driver3LastName { get; set; }
//        public string Driver3Email { get; set; }
//        public string Driver3License { get; set; }

       
//        public string Driver4FirstName { get; set; }
//        public string Driver4LastName { get; set; }
//        public string Driver4Email { get; set; }
//        public string Driver4License { get; set; }

        
//        public int DriverCount { get; set; }

//        public int SectionCodeId { get; set; }

//        public string LesseSearch { get; set; }
//        public string LessorSearch { get; set; }
//        public string LeinholderSearch { get; set; }
//        public string DriverSearch { get; set; }

//        public string LesseName { get; set; }

//        public int Status { get; set; }

//        public bool IsLimo { get; set; }

//        public string MunicipalityCode { get; set; }


//        public System.DateTime? CancellationDate { get; set; }
//        public string CancellationReason { get; set; }
//        public System.DateTime? CertificateAdditionDate { get; set; }

//        public Nullable<decimal> Premium { get; set; }
//        public Nullable<decimal> SD { get; set; }
//        public Nullable<decimal> Corridor { get; set; }
//        public Nullable<decimal> Total { get; set; }

//        public string LessorName { get; set; }
//        public string LessorAddress { get; set; }
//        public string LessorCity { get; set; }
//        public string LessorProvince { get; set; }
//        public string LessorZipCode { get; set; }

//        public string LesseAddress { get; set; }
//        public string LesseCity { get; set; }
//        public string LesseProvince { get; set; }
//        public string LesseZipCode { get; set; }

//        public string InsuranceCompany { get; set; }
//        public string PolicyNo { get; set; }
//        public string OntProvPlate { get; set; }

//        public Nullable<int> ErrorId { get; set; }
        
//        public List<AuditLogModel> AuditList { get; set; }

//        public string Certificate { get; set; }
//        public string CertificateName { get; set; }
//        public string PinkSlip { get; set; }
//        public string CancelationCertificate { get; set; }
//        public string BrokerCertificate { get; set; }

//        public string SectionCode { get; set; }
//        public string Error { get; set; }

//        public VehicleDetailsModel()
//        {


//        }
//        public bool IsActive { get; set; }
//        public VehicleDetailsModel(VehicleDetail obj)
//        {


//            this.Id = obj.Id;

//            this.FleetId = obj.FleetId;
//            this.AddedByApniMaa = obj.AddedByApniMaa;
//            this.AddedByFleet = obj.AddedByFleet;
//            this.ApniMaaRefrenceID = obj.ApniMaaRefrenceID;
//            this.VIM = obj.VIM;
//            this.RIM = obj.RIM;
//            this.PlateNumber = obj.PlateNumber;

//            this.CreatedDate=obj.CreatedDate;
//            this.LastModified=obj.LastModified;
//            this.IsLeased=obj.IsLeased;
//            this.IsFinanced=obj.IsFinanced;
//            this.LesseId = obj.LesseId;
//            this.LessorId = obj.LessorId;
//            this.LeinholderId = obj.LeinholderId;
//            this.IsLessorDriver = obj.IsLessorDriver;
//            this.Coverage_DCPD = obj.Coverage_DCPD;
//            this.Coverage_COLL = obj.Coverage_COLL;
//            this.Coverage_COMP = obj.Coverage_COMP;
//            this.EffectiveDate = obj.EffectiveDate;
//            this.Expiry = obj.Expiry;
//            this.CreatedDate = obj.CreatedDate;
//            this.LastModified = obj.LastModified;
//            this.IsLeased = obj.IsLeased;
//            this.IsFinanced = obj.IsFinanced;
//            this.IsLesseDriver = obj.IsLesseDriver;

//            this.Coverage_DCPD = obj.Coverage_DCPD;
//            this.Coverage_COLL = obj.Coverage_COLL;
//            this.Coverage_COMP = obj.Coverage_COMP;
//            if (obj.EffectiveDate.HasValue)
//                this.EffectiveDate = obj.EffectiveDate.Value;


//            this.ComissionId = obj.ComissionId;
//            if (obj.Comission != null)
//            {
//                this.MunicipalityCode = obj.Comission.MunicipalityPrefixes.FirstOrDefault().Value;
//                this.Municipality = obj.Comission.MunicipalityName;
//            }
//            this.IsActive = obj.IsActive;
//            this.Status = obj.Status;
            
//            this.VehicleType = obj.VehicleType;
//            this.Make = obj.Make;
//            this.Manufacturer_Name = obj.Manufacturer_Name;
//            this.Model = obj.Model;
//            this.Model_Year = obj.Model_Year;
//            this.Series = obj.Series;
//            this.Vehicle_Type = obj.Vehicle_Type;
//            this.Body_Class = obj.Body_Class;
//            this.Steering_Location = obj.Steering_Location;
//            this.Drive_Type = obj.Drive_Type;
//            this.SectionCodeId = obj.SectionCodeId;
//            this.LesseName = (obj.User2 != null) ? obj.User2.FirstName + " " + obj.User2.LastName : "";
//            this.LesseSearch = (obj.User2 != null) ? ((obj.User2.UserInformation != null) ? (obj.User2.UserInformation.LicenceNumber.ToString()) : obj.User2.FirstName+" "+obj.User2.LastName) : "";
//            this.LessorSearch = (obj.User3 != null) ? ((obj.User3.UserInformation != null) ? (obj.User3.UserInformation.LicenceNumber.ToString()) : obj.User3.FirstName + " " + obj.User3.LastName) : "";
//            this.LeinholderSearch = (obj.User1 != null) ? ((obj.User1.UserInformation != null) ? (obj.User1.UserInformation.LicenceNumber.ToString()) : obj.User1.FirstName + " " + obj.User1.LastName) : "";
//            this.IsLimo = obj.IsLimo;
//            if (obj.Noc != null)
//            {
//                this.Noc = "/Documents/Noc/" + obj.FleetId + "/" + obj.Noc;
//            }


//            if (obj.Fleet != null)
//            {
//                this.FleetName = obj.Fleet.FleetName;
//            }

//            this.CancellationDate = obj.CancellationDate;
//            this.CancellationReason = obj.CancellationReason;
//            this.CertificateAdditionDate = obj.CertificateAdditionDate;
//            this.Premium = obj.Premium;
//            this.Corridor = obj.Corridor;
//            this.SD = obj.SD;
//            this.LessorName = obj.User3.FirstName + " " + obj.User3.LastName;
//            if (obj.User3.UserContactDetails != null)
//            {
//                if (obj.User3.UserContactDetails.Count > 0)
//                {
//                    this.LessorAddress = obj.User3.UserContactDetails.FirstOrDefault().StreetAddress;
//                    this.LessorCity = obj.User3.UserContactDetails.FirstOrDefault().City.Name;
//                    this.LessorProvince = obj.User3.UserContactDetails.FirstOrDefault().City.Province.Name;
//                    this.LessorZipCode = obj.User3.UserContactDetails.FirstOrDefault().PostalCode;
//                }
//            }
//            if(obj.LesseId.HasValue)
//            {
//                if (obj.User2.UserContactDetails != null)
//                {
//                    if (obj.User2.UserContactDetails.Count > 0)
//                    {
//                        this.LesseName = obj.User2.FirstName + " " + obj.User2.LastName;
//                        this.LesseAddress = obj.User2.UserContactDetails.FirstOrDefault().StreetAddress;
//                        this.LesseCity = obj.User2.UserContactDetails.FirstOrDefault().City.Name;
//                        this.LesseProvince = obj.User2.UserContactDetails.FirstOrDefault().City.Province.Name;
//                        this.LesseZipCode = obj.User2.UserContactDetails.FirstOrDefault().PostalCode;
//                    }
//                }
//            }

//            this.InsuranceCompany = obj.Fleet.InsuranceCompany;
//            var Policy = obj.Fleet.Policies.Where(p => ((obj.VehicleType == 1) ? p.SEffectiveDate : p.MEffectiveDate) <= DateTime.Now && ((obj.VehicleType == 1) ? p.MEffectiveDate : p.MExpiryDate) >= DateTime.Now).OrderByDescending(p => p.LastModified).FirstOrDefault();
//            if (Policy != null)
//            {
//                this.PolicyNo = (obj.VehicleType == 1) ? Policy.SPolicyNumber : Policy.MPolicyNumber;
//            }
//            this.OntProvPlate = obj.OntProvPlate;
//            if (obj.Certificate != null)
//            {
//                this.Certificate = "../../Documents/Certificate/" + obj.FleetId + "/" + obj.Certificate;
//                this.CertificateName = obj.Certificate;
//            }
//            if (obj.PinkSlip != null)
//            {
//                this.PinkSlip = "../../Documents/PinkSlip/" + obj.FleetId + "/" + obj.PinkSlip;
//            }
//            if (obj.BrokerCertificate != null)
//            {
//                this.BrokerCertificate = "../../Documents/BrokerCertificate/" + obj.FleetId + "/" + obj.BrokerCertificate;
//            }
//            if (obj.CancelationCertificate != null)
//            {
//                this.CancelationCertificate = "../../Documents/CancellationCertificate/" + obj.FleetId + "/" + obj.CancelationCertificate;
//            }
//            this.ErrorId = obj.ErrorId;
//            if (obj.SectionCode != null)
//            {
//                this.SectionCode = obj.SectionCode.Name;
//            }
//            this.Error = (obj.ErrorList != null) ? obj.ErrorList.CODE : "-";
//        }
//    }

//    public class GeneratePDFModel 
//    {
//        public VehicleDetailsModel VehicleDetails { get; set; }
//        public string PartialViewName { get; set; }
//        public string FilePath { get; set; }
//        public string FileName { get; set; }

//        public string SlipFilePath { get; set; }
//        public string SlipFileName { get; set; }

//        public string BrokerFilePath { get; set; }
//        public string BrokerFileName { get; set; }

//        public string CancelFilePath { get; set; }
//        public string CancelFileName { get; set; }

//        public string TemplateFilePath { get; set; }
//    }
//}
