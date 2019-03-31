
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ApniMaa.BLL.Common;;
//using ApniMaa.DAL;

//namespace ApniMaa.BLL.Models
//{

//    public class PremiumBordereauListingModel
//    {
//        public int Broker { get; set; }
//        public string PolicyNumber { get; set; }
//        public string Plate { get; set; }
//        public string ErrorCode { get; set; }
//        public string Insured { get; set; }
//        public string StreetAddress { get; set; }
//        public string City { get; set; }
//        public string PostalCode { get; set; }
//        public string Province { get; set; }
//        public string RIN { get; set; }
//        public DateTime? ProcessingDate { get; set; }
//        public DateTime? EffectiveDate { get; set; }
//        public DateTime? ExpiryDate { get; set; }
//        public string PolicyLimit { get; set; }
//        public string TransactionType { get; set; }
//        public string VehicleDescription { get; set; }
//        public int VehicleDescriptionCount { get; set; }
//        public decimal TotalLiabilityPremium { get; set; }
//        public string TPLBI_PDPrem { get; set; }
//        public string DCPD_Prem { get; set; }
//        public int? DCPD_Ded { get; set; }
//        public int OPCF44_SEF44 { get; set; }
//        public string AB_Prem { get; set; }
//        public string UninsuredAutoPremium { get; set; }
//        public int TotalPDPremium { get; set; }
//        public int CollisionPrem { get; set; }
//        public int CollisionDed { get; set; }
//        public int AllPerilsPrem { get; set; }
//        public int AllPerilsDed { get; set; }
//        public int Collision_AllPerilsPrem { get; set; }
//        public int ComprehensivePrem { get; set; }
//        public int ComprehensiveDed { get; set; }
//        public int SpecifiedPerilsPrem { get; set; }
//        public int SpecifiedPerilsDed { get; set; }
//        public int Comp_SpecPerilsDed { get; set; }
//        public decimal TotalLiability_PDPremium { get; set; }
//        public string StatTerr { get; set; }
//        public int TypeofBus { get; set; }
//        public int TypeofUse { get; set; }
//        public string VIN { get; set; }
//        public string VehicleLocationPostalCode { get; set; }
//        public string ABDrivingRecord { get; set; }
//        public int Collision_AllPerilsDrivingRecord { get; set; }
//        public int TPLDrivingRecord { get; set; }
//        public string POLastName { get; set; }
//        public string POFirstName { get; set; }
//        public string PODLNo { get; set; }
        

//        public PremiumBordereauListingModel() { }

//        public PremiumBordereauListingModel(Transaction model)
//        {
//            if (model.VehicleDetail != null) 
//            {
//                this.Broker = 9999;
//                this.PolicyNumber = model.VehicleDetail.Fleet.Policies.FirstOrDefault().SPolicyNumber;
//                this.Plate = model.VehicleDetail.PlateNumber;
//                this.Insured = model.VehicleDetail.Fleet.InsuranceCompany;

//                var lessorId = model.VehicleDetail.LessorId;
//                var user = model.VehicleDetail.User;

//                if (model.VehicleDetail.User != null)
//                {
//                    if (model.VehicleDetail.User.UserId == lessorId)
//                        user = model.VehicleDetail.User;
//                }
//                if (model.VehicleDetail.User1 != null)
//                {
//                    if (model.VehicleDetail.User1.UserId == lessorId)
//                        user = model.VehicleDetail.User1;
//                }
//                if (model.VehicleDetail.User2 != null)
//                {
//                    if (model.VehicleDetail.User2.UserId == lessorId)
//                        user = model.VehicleDetail.User2;
//                }
//                if (model.VehicleDetail.User3 != null)
//                {
//                    if (model.VehicleDetail.User3.UserId == lessorId)
//                        user = model.VehicleDetail.User3;
//                }

//                if (user != null)
//                {

//                    this.POFirstName = user.FirstName;
//                    this.POLastName = user.LastName;
//                    if (user.UserInformation != null)
//                        this.PODLNo = user.UserInformation.LicenceNumber;

//                }
//                if (user != null)
//                {
//                    if (user.UserContactDetails != null)
//                    {
//                        if (user.UserContactDetails.Count>0)
//                        {
//                            this.StreetAddress = user.UserContactDetails.FirstOrDefault().StreetAddress;
//                            this.City = user.UserContactDetails.FirstOrDefault().City.Name;
//                            this.PostalCode = user.UserContactDetails.FirstOrDefault().PostalCode;
//                            this.Province = user.UserContactDetails.FirstOrDefault().City.Province.Name;
//                        }
//                    }
//                }

//                this.RIN = model.VehicleDetail.RIM;
//                this.ProcessingDate = model.VehicleDetail.EffectiveDate;
//                this.EffectiveDate = model.VehicleDetail.EffectiveDate;
//                this.ExpiryDate = model.VehicleDetail.Expiry;

//                this.PolicyLimit = "2,000,000";
//                this.TransactionType = ((TransactionType)model.TransactionType).ToString();

//                if (model.VehicleDetail.IsLimo)
//                {
//                    this.VehicleDescription = "LIMOUSINE";
//                }
//                else
//                {
//                    this.VehicleDescription = "TAXI";
//                }

//                this.VehicleDescriptionCount = 1;
//                this.TotalLiabilityPremium = model.Total;
//                this.TPLBI_PDPrem = "";
//                this.DCPD_Prem = "";
//                this.DCPD_Ded = model.VehicleDetail.Coverage_DCPD;
//                this.OPCF44_SEF44 = 0;
//                this.AB_Prem = "";
//                this.UninsuredAutoPremium = "";
//                this.TotalPDPremium = 0;
//                this.CollisionPrem = 0;
//                this.CollisionDed = 0;
//                this.AllPerilsPrem = 0;
//                this.AllPerilsDed = 0;
//                this.Collision_AllPerilsPrem = 0;
//                this.ComprehensivePrem = 0;
//                this.ComprehensiveDed = 0;
//                this.SpecifiedPerilsPrem = 0;
//                this.SpecifiedPerilsDed = 0;
//                this.Comp_SpecPerilsDed = 0;
//                this.TotalLiability_PDPremium = model.Total;
//                this.StatTerr = model.VehicleDetail.Comission.TerritoryCode;
//                this.TypeofBus = 4;
//                this.TypeofUse = 77;
//                this.VIN = model.VehicleDetail.VIM;
//                this.ErrorCode = (model.VehicleDetail.ErrorList!=null)?model.VehicleDetail.ErrorList.CODE:"";

//                if (user != null)
//                {
//                    if (user.UserContactDetails != null)
//                    {
//                        if (user.UserContactDetails.Count > 0)
//                        {
//                            this.VehicleLocationPostalCode = user.UserContactDetails.FirstOrDefault().StreetAddress + " " + user.UserContactDetails.FirstOrDefault().PostalCode;
//                        }
//                    }
//                    if (user.UserInformation != null)
//                        this.ABDrivingRecord = (user.UserInformation != null) ? user.UserInformation.LicenceNumber : "";
//                }

//                this.Collision_AllPerilsDrivingRecord = 4;
//                this.TPLDrivingRecord = 4;
//            }
//        }
//    }

//    public class PremiumBordereauFleetListingModel
//    {
//        public string PlateNo { get; set; }
//        public string CertNo { get; set; }
//        public string Group { get; set; }
//        public string OwnerLessor { get; set; }
//        public string OwnerAddress { get; set; }
//        public string OwnerCity { get; set; }
//        public string OwnerProvince { get; set; }
//        public string OwnerPostalCode { get; set; }
//        public string EnteredDate { get; set; }
//        public string EffectiveDate { get; set; }
//        public string Renewal { get; set; }
//        public string TransactionType { get; set; }
//        public string Make { get; set; }
//        public string Model { get; set; }
//        public string Year { get; set; }
//        public string VIN { get; set; }
//        public string Section { get; set; }
//        public string Municipality { get; set; }
//        public string FTPremium { get; set; }
//        public string Surcharge { get; set; }
//        public string PRPremium { get; set; }
//        public int? Deduct { get; set; }
//        public string Retention { get; set; }
//        public string POLast { get; set; }
//        public string POFirst { get; set; }
//        public string POLicense { get; set; }
//        public string Days { get; set; }
//        public string Notes { get; set; }
//        public string ChangedBy { get; set; }

//        public PremiumBordereauFleetListingModel() { }

//        public PremiumBordereauFleetListingModel(Transaction model)
//        {
//            this.PlateNo = model.VehicleDetail.PlateNumber;
//            this.CertNo = model.VehicleDetail.ApniMaaRefrenceID;
//            this.Group = "";

//            var lessorId = model.VehicleDetail.LessorId;
//            var user = model.VehicleDetail.User;

//            if (model.VehicleDetail.User != null)
//            {
//                if (model.VehicleDetail.User.UserId == lessorId)
//                    user = model.VehicleDetail.User;
//            }
//            if (model.VehicleDetail.User1 != null)
//            {
//                if (model.VehicleDetail.User1.UserId == lessorId)
//                    user = model.VehicleDetail.User1;
//            }
//            if (model.VehicleDetail.User2 != null)
//            {
//                if (model.VehicleDetail.User2.UserId == lessorId)
//                    user = model.VehicleDetail.User2;
//            }
//            if (model.VehicleDetail.User3 != null)
//            {
//                if (model.VehicleDetail.User3.UserId == lessorId)
//                    user = model.VehicleDetail.User3;
//            }

//            if (user != null)
//            {
//                this.POFirst = user.FirstName;
//                this.POLast = user.LastName;
//                if (user.UserInformation != null)
//                    this.POLicense = user.UserInformation.LicenceNumber;
//            }

//            if (user != null)
//            {
//                this.OwnerLessor = string.Format("{0} {1}", user.FirstName, user.LastName);
//                if (user.UserContactDetails != null)
//                {
//                    this.OwnerAddress = user.UserContactDetails.FirstOrDefault().StreetAddress;
//                    this.OwnerCity = user.UserContactDetails.FirstOrDefault().City.Name;
//                    this.OwnerProvince = user.UserContactDetails.FirstOrDefault().City.Province.Name;
//                    this.OwnerPostalCode = user.UserContactDetails.FirstOrDefault().PostalCode;
//                }
//            }


//            this.EnteredDate = model.VehicleDetail.EffectiveDate.HasValue ? UtilitiesHelp.ToMonthName(model.VehicleDetail.CertificateAdditionDate.Value) : string.Empty;
//            this.EffectiveDate = model.VehicleDetail.EffectiveDate.HasValue ? UtilitiesHelp.ToMonthName(model.VehicleDetail.EffectiveDate.Value) : string.Empty;

//            if (model.TransactionType == (int)ApniMaa.Services.Models.TransactionType.Renew)
//            {
//                this.Renewal = UtilitiesHelp.ToMonthName(model.TransactionDate);
//            }

//            this.TransactionType = ((TransactionType)model.TransactionType).ToString();
//            this.Make = model.VehicleDetail.Make;
//            this.Model = model.VehicleDetail.Model;
//            this.Year = model.VehicleDetail.Model_Year;
//            this.VIN = model.VehicleDetail.VIM;
//            if (model.VehicleDetail.SectionCode != null)
//                this.Section = model.VehicleDetail.SectionCode.Name;

//            if (model.VehicleDetail.Comission != null)
//                this.Municipality = model.VehicleDetail.Comission.MunicipalityName;
//            this.FTPremium = string.Empty;
//            this.Surcharge = string.Empty;
//            this.PRPremium = string.Empty;
//            this.Deduct = (model.VehicleDetail.Coverage_DCPD + model.VehicleDetail.Coverage_COLL + model.VehicleDetail.Coverage_COMP);
//            this.Retention = string.Empty;
//            this.Days = string.Empty;
//            this.Notes = string.Empty;
//            this.ChangedBy = string.Empty;
//        }
//    }

//    public class PremiumBordereauIDCListingModel
//    {
//        public string Version { get; set; }
//        public string Activity { get; set; }
//        public string ErrorCode { get; set; }
//        public string AgentId { get; set; }
//        public string ProgramId { get; set; }
//        public string PolicyNumber { get; set; }
//        public string PolicyType { get; set; }
//        public string EndorsementNumber { get; set; }
//        public string LocationNumber { get; set; }
//        public string UnitNumber { get; set; }
//        public string AnnualStatementLine { get; set; }
//        public string ClassCode { get; set; }
//        public string Subline { get; set; }
//        public string CoverageCode { get; set; }
//        public string SubCoverageCode { get; set; }
//        public string PremiumType { get; set; }
//        public string PolicyEffectiveDate { get; set; }
//        public string PolicyExpirationDate { get; set; }
//        public string TransactionEffectiveDate { get; set; }
//        public string TransactionProcessedDate { get; set; }
//        public string PolicyTransaction { get; set; }
//        public string Transaction { get; set; }
//        public string VIN { get; set; }
//        public string AddressLine1 { get; set; }
//        public string AddressLine2 { get; set; }
//        public string CityName { get; set; }
//        public string Providence { get; set; }
//        public string PostalCode { get; set; }
//        public string Territory { get; set; }
//        public string OccurrenceLimit { get; set; }
//        public string Exposure { get; set; }
//        public string LossCostMultiplier { get; set; }
//        public string RatingID { get; set; }
//        public string ScheduleModifier { get; set; }
//        public string ExperienceModifier { get; set; }
//        public string RateModificationFactor { get; set; }
//        public string NetPremiumChange { get; set; }
//        public string IBCVersionNumber { get; set; }
//        public string CertificateNumber { get; set; }
//        public string VehicleLocation { get; set; }
//        public string TypeofBusiness { get; set; }
//        public string TypeofUse { get; set; }
//        public string TrailerIndicator { get; set; }
//        public string PolicyVehicleStatus { get; set; }
//        public string IBCCoverageCode { get; set; }
//        public string AddedCoverageToOffsetTortDeductible { get; set; }
//        public string ABOptionalCoverageMandR { get; set; }
//        public string ABOptionalCoverageAC { get; set; }
//        public string ABOptionalCoverageCHandHM { get; set; }
//        public string ABOptionalCoverageIR { get; set; }
//        public string ABOptionalCoverageDC { get; set; }
//        public string ABOptionalCoverageDandF { get; set; }
//        public string ABOptionalCoverageI { get; set; }
//        public string CompanyUse { get; set; }
//        public decimal Premium { get; set; }
//        public int Renewals { get; set; }
//        public int CertId { get; set; }

//        public PremiumBordereauIDCListingModel() { }
//        public PremiumBordereauIDCListingModel(Transaction model,int Month,int Year)
//        {
//            if (model.VehicleDetail != null)
//            {
                
//                if(model.VehicleDetail.VehicleType==(int)VehicleType.Single)
//                {
//                    this.PolicyNumber = model.VehicleDetail.Fleet.Policies.Where(p => p.SEffectiveDate.Year >= Year).OrderByDescending(p => p.CreatedDate).FirstOrDefault().SPolicyNumber + "." + model.VehicleDetail.ApniMaaRefrenceID;
//                    this.PolicyEffectiveDate = model.VehicleDetail.Fleet.Policies.Where(p => p.SEffectiveDate.Year >= Year).OrderByDescending(p => p.CreatedDate).FirstOrDefault().SEffectiveDate.ToString("MM/dd/yyyy");
//                    this.PolicyExpirationDate = model.VehicleDetail.Fleet.Policies.Where(p => p.SEffectiveDate.Year >= Year).OrderByDescending(p => p.CreatedDate).FirstOrDefault().SExpiryDate.ToString("MM/dd/yyyy");
//                }
//                else
//                {
//                    this.PolicyNumber = model.VehicleDetail.Fleet.Policies.Where(p =>  p.MExpiryDate.Year >= Year).OrderByDescending(p => p.CreatedDate).FirstOrDefault().MPolicyNumber + "." + model.VehicleDetail.ApniMaaRefrenceID;
//                    this.PolicyEffectiveDate = model.VehicleDetail.Fleet.Policies.Where(p => p.MEffectiveDate.Year >= Year).OrderByDescending(p => p.CreatedDate).FirstOrDefault().MEffectiveDate.ToString("MM/dd/yyyy");
//                    this.PolicyExpirationDate = model.VehicleDetail.Fleet.Policies.Where(p => p.MEffectiveDate.Year >= Year).OrderByDescending(p => p.CreatedDate).FirstOrDefault().MExpiryDate.ToString("MM/dd/yyyy");
//                }
                
//                this.ErrorCode = (model.VehicleDetail.ErrorList!=null)?model.VehicleDetail.ErrorList.CODE:"";
//                this.Version = "1.2.3CA_IBC";
//                this.Activity = "Transaction";
//                this.AgentId = "12345";
//                this.ProgramId = "12345";
//                this.PolicyType = "10";
//                this.EndorsementNumber = "0";
//                this.LocationNumber = "";
//                this.UnitNumber = "1";
//                this.AnnualStatementLine = "194";
//                this.ClassCode = "7040";
//                this.Subline = "611";
//                this.SubCoverageCode = "";
//                this.PremiumType = "Premium";
//                this.TransactionEffectiveDate = model.TransactionDate.ToString("MM/dd/yyyy");
//                this.TransactionProcessedDate = model.TransactionDate.ToString("MM/dd/yyyy");
//                this.PolicyTransaction = "New Business";
//                this.Transaction = (model.TransactionType == (int)TransactionType.New || model.TransactionType == (int)TransactionType.Renew) ? "Add" : "Delete";
//                this.VIN = model.VehicleDetail.VIM;
//                this.AddressLine1 = model.VehicleDetail.Fleet.StreetAddress;
//                this.AddressLine2 = "";
//                this.CityName = model.VehicleDetail.Fleet.City.Name;
//                this.Providence = model.VehicleDetail.Fleet.City.Province.Code;
//                this.PostalCode = model.VehicleDetail.Fleet.PostalCode;
//                this.Territory = "710";
//                this.OccurrenceLimit = "0";
//                this.Exposure = "10";
//                this.LossCostMultiplier = "1";
//                this.RatingID = "1";
//                this.ScheduleModifier = "1";
//                this.ExperienceModifier = "1";
//                this.RateModificationFactor = "1";
//                this.IBCVersionNumber = "1";
//                this.CertificateNumber = model.VehicleDetail.ApniMaaRefrenceID;
//                this.VehicleLocation = model.VehicleDetail.Fleet.PostalCode.Substring(0,3);
//                this.TypeofBusiness = "4";
//                this.TypeofUse = "77";
//                this.TrailerIndicator = "N";
//                this.PolicyVehicleStatus = "90";
//                this.IBCCoverageCode = "78";
//                this.AddedCoverageToOffsetTortDeductible = "0";
//                this.ABOptionalCoverageAC = "0";
//                this.ABOptionalCoverageMandR = "0";
//                this.ABOptionalCoverageCHandHM = "0";
//                this.ABOptionalCoverageIR = "0";
//                this.ABOptionalCoverageDC = "0";
//                this.ABOptionalCoverageDandF = "0";
//                this.ABOptionalCoverageI = "0";
//                this.CompanyUse = "";
//                this.Premium = model.Premium;
//                this.CertId = model.VehicleDetail.Id;
//            }
//        }

//        public PremiumBordereauIDCListingModel(PremiumBordereauIDCListingModel model)
//        {
//        this.Version=model.Version;
//        this.Activity=model.Activity;
//        this.ErrorCode=model.ErrorCode;
//        this.AgentId=model.AgentId;
//        this.ProgramId=model.ProgramId;
//        this.PolicyNumber=model.PolicyNumber;
//        this.PolicyType=model.PolicyType;
//        this.EndorsementNumber=model.EndorsementNumber;
//        this.LocationNumber=model.LocationNumber;
//        this.UnitNumber=model.UnitNumber;
//        this.AnnualStatementLine=model.AnnualStatementLine;
//        this.ClassCode = model.ClassCode;
//        this.Subline = model.Subline;
//        this.CoverageCode = model.CoverageCode;
//        this.SubCoverageCode = model.SubCoverageCode;
//        this.PremiumType = model.PremiumType;
//        this.PolicyEffectiveDate = model.PolicyEffectiveDate;
//        this.PolicyExpirationDate = model.PolicyExpirationDate;
//        this.TransactionEffectiveDate = model.TransactionEffectiveDate;
//        this.TransactionProcessedDate = model.TransactionProcessedDate;
//        this.PolicyTransaction = model.PolicyTransaction;
//        this.Transaction = model.Transaction;
//        this.VIN = model.VIN;
//        this.AddressLine1 = model.AddressLine1;
//        this.AddressLine2 = model.AddressLine2;
//        this.CityName = model.CityName;
//        this.Providence = model.Providence;
//        this.PostalCode = model.PostalCode;
//        this.Territory = model.Territory;
//        this.OccurrenceLimit = model.OccurrenceLimit;
//        this.Exposure = model.Exposure;
//        this.LossCostMultiplier = model.LossCostMultiplier;
//        this.RatingID = model.RatingID;
//        this.ScheduleModifier = model.ScheduleModifier;
//        this.ExperienceModifier = model.ExperienceModifier;
//        this.RateModificationFactor =model.RateModificationFactor;
//        this.NetPremiumChange =model.NetPremiumChange;
//        this.IBCVersionNumber=model.IBCVersionNumber;
//        this.CertificateNumber =model.CertificateNumber;
//        this.VehicleLocation =model.VehicleLocation;
//        this.TypeofBusiness =model.TypeofBusiness;
//        this.TypeofUse =model.TypeofUse;
//        this.TrailerIndicator  =model.TrailerIndicator;
//        this.PolicyVehicleStatus  =model.PolicyVehicleStatus;
//        this.IBCCoverageCode =model.IBCCoverageCode;
//        this.AddedCoverageToOffsetTortDeductible =model.AddedCoverageToOffsetTortDeductible;
//        this.ABOptionalCoverageMandR =model.ABOptionalCoverageMandR;
//        this.ABOptionalCoverageAC =model.ABOptionalCoverageAC;
//        this.ABOptionalCoverageCHandHM =model.ABOptionalCoverageCHandHM;
//        this.ABOptionalCoverageIR =model.ABOptionalCoverageIR;
//        this.ABOptionalCoverageDC =model.ABOptionalCoverageDC;
//        this.ABOptionalCoverageDandF =model.ABOptionalCoverageDandF;
//        this.ABOptionalCoverageI =model.ABOptionalCoverageI;
//        this.CompanyUse = model.CompanyUse;
//        this.NetPremiumChange = model.NetPremiumChange;
//        this.CoverageCode = model.CoverageCode;
//        this.Renewals = model.Renewals;
//        }
//    }

//    public class InsuredIDCListingModel
//    {
//        public string Version { get; set; }
//        public string Activity { get; set; }
//        public string ErrorCode { get; set; }
       
//        public string PolicyNumber { get; set; }
//        public string EndorsementNumber { get; set; }
//        public string PolicyTransaction { get; set; }
//        public string Transaction { get; set; }

//        public string PolicyEffectiveDate { get; set; }
//        public string PolicyExpirationDate { get; set; }
//        public string TransactionEffectiveDate { get; set; }
//        public string AddressLine1 { get; set; }
//        public string AddressLine2 { get; set; }
//        public string CityName { get; set; }
//        public string Providence { get; set; }
//        public string PostalCode { get; set; }


//        public string Number { get; set; }
//        public string FullName{ get; set; }
//        public string FirstName { get; set; }
//        public string MiddleName { get; set; }
//        public string LastName { get; set; }
//        public string Suffix { get; set; }
//        public string Fax { get; set; }
//        public string FEIN { get; set; }
//        public string DriversLicenseNumber { get; set; }

//        public string CompanyUse { get; set; }
//        public int Renewals { get; set; }
//        public int CertId { get; set; }

//        public InsuredIDCListingModel() { }
//        public InsuredIDCListingModel(Transaction model, int Month, int Year)
//        {
//            if (model.VehicleDetail != null)
//            {

//                if (model.VehicleDetail.VehicleType == (int)VehicleType.Single)
//                {
//                    this.PolicyNumber = model.VehicleDetail.Fleet.Policies.Where(p => p.SEffectiveDate.Year >= Year).OrderByDescending(p => p.CreatedDate).FirstOrDefault().SPolicyNumber + "." + model.VehicleDetail.ApniMaaRefrenceID;
//                    this.PolicyEffectiveDate = model.VehicleDetail.Fleet.Policies.Where(p => p.SEffectiveDate.Year >= Year).OrderByDescending(p => p.CreatedDate).FirstOrDefault().SEffectiveDate.ToString("MM/dd/yyyy");
//                    this.PolicyExpirationDate = model.VehicleDetail.Fleet.Policies.Where(p => p.SEffectiveDate.Year >= Year).OrderByDescending(p => p.CreatedDate).FirstOrDefault().SExpiryDate.ToString("MM/dd/yyyy");
//                }
//                else
//                {
//                    this.PolicyNumber = model.VehicleDetail.Fleet.Policies.Where(p => p.MExpiryDate.Year >= Year).OrderByDescending(p => p.CreatedDate).FirstOrDefault().MPolicyNumber + "." + model.VehicleDetail.ApniMaaRefrenceID;
//                    this.PolicyEffectiveDate = model.VehicleDetail.Fleet.Policies.Where(p => p.MEffectiveDate.Year >= Year).OrderByDescending(p => p.CreatedDate).FirstOrDefault().MEffectiveDate.ToString("MM/dd/yyyy");
//                    this.PolicyExpirationDate = model.VehicleDetail.Fleet.Policies.Where(p => p.MEffectiveDate.Year >= Year).OrderByDescending(p => p.CreatedDate).FirstOrDefault().MExpiryDate.ToString("MM/dd/yyyy");
//                }

//                this.ErrorCode = (model.VehicleDetail.ErrorList != null) ? model.VehicleDetail.ErrorList.CODE : "";
//                this.Version = "1.2.2 Insured_IBC";
//                this.Activity = "Transaction";
               
//                this.EndorsementNumber = "0";
                
//                this.TransactionEffectiveDate = model.TransactionDate.ToString("MM/dd/yyyy");
               
//                this.PolicyTransaction = "New Business";
//                this.Transaction = (model.TransactionType == (int)TransactionType.New || model.TransactionType == (int)TransactionType.Renew) ? "Add" : "Delete";
                
//                this.AddressLine1 = model.VehicleDetail.Fleet.StreetAddress;
//                this.AddressLine2 = "";
//                this.CityName = model.VehicleDetail.Fleet.City.Name;
//                this.Providence = model.VehicleDetail.Fleet.City.Province.Code;
//                this.PostalCode = model.VehicleDetail.Fleet.PostalCode;
               
//                this.CompanyUse = "";
//                this.Number ="";
//                this.FullName=model.VehicleDetail.Fleet.FleetName;
//                this.FirstName ="";
//                this.MiddleName ="";
//                this.LastName ="";
//                this.Suffix ="";
//                this.Fax ="";
//                this.FEIN ="";
//                this.DriversLicenseNumber = "";
//                this.CertId = model.VehicleDetail.Id;
//            }
//        }

        
//    }

//    public class ControlIDCListingModel
//    {
//        public string Version { get; set; }
       

//        public string PolicyNumber { get; set; }
        

//        public string PolicyEffectiveDate { get; set; }
//        public string PolicyExpirationDate { get; set; }
//        public decimal Total_Policy_Value { get; set; }
//        public decimal Total_Written_Premium { get; set; }
//        public decimal Total_Fees_Taxes_Surcharges_Amount{get;set;}
//        public decimal Invoiced_To_Date { get; set; }
        
//        public int Renewals { get; set; }
//        public int Type { get; set; }
//        public int CertId { get; set; }

//        public ControlIDCListingModel() { }
//        public ControlIDCListingModel(Transaction model, int Month, int Year)
//        {
//            if (model.VehicleDetail != null)
//            {

//                if (model.VehicleDetail.VehicleType == (int)VehicleType.Single)
//                {
//                    this.PolicyNumber = model.VehicleDetail.Fleet.Policies.Where(p => p.SEffectiveDate.Year >= Year).OrderByDescending(p => p.CreatedDate).FirstOrDefault().SPolicyNumber + "." + model.VehicleDetail.ApniMaaRefrenceID;
//                    this.PolicyEffectiveDate = model.VehicleDetail.Fleet.Policies.Where(p => p.SEffectiveDate.Year >= Year).OrderByDescending(p => p.CreatedDate).FirstOrDefault().SEffectiveDate.ToString("MM/dd/yyyy");
//                    this.PolicyExpirationDate = model.VehicleDetail.Fleet.Policies.Where(p => p.SEffectiveDate.Year >= Year).OrderByDescending(p => p.CreatedDate).FirstOrDefault().SExpiryDate.ToString("MM/dd/yyyy");
//                }
//                else
//                {
//                    this.PolicyNumber = model.VehicleDetail.Fleet.Policies.Where(p => p.MExpiryDate.Year >= Year).OrderByDescending(p => p.CreatedDate).FirstOrDefault().MPolicyNumber + "." + model.VehicleDetail.ApniMaaRefrenceID;
//                    this.PolicyEffectiveDate = model.VehicleDetail.Fleet.Policies.Where(p => p.MEffectiveDate.Year >= Year).OrderByDescending(p => p.CreatedDate).FirstOrDefault().MEffectiveDate.ToString("MM/dd/yyyy");
//                    this.PolicyExpirationDate = model.VehicleDetail.Fleet.Policies.Where(p => p.MEffectiveDate.Year >= Year).OrderByDescending(p => p.CreatedDate).FirstOrDefault().MExpiryDate.ToString("MM/dd/yyyy");
//                }

//                this.Total_Fees_Taxes_Surcharges_Amount = 0;
//                this.Total_Policy_Value = this.Total_Written_Premium = this.Invoiced_To_Date = model.Premium;
//                this.Version = "Control File 1.1.0";
//                this.CertId = model.VehicleDetail.Id;
//                this.Type = model.TransactionType;
//            }
//        }


//    }

//}
