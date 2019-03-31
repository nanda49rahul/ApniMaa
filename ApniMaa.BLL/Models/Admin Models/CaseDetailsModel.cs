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
//    public class CaseDetailsModel
//    {
//        public int Id { get; set; }
//        public string LiscRefrenceID { get; set; }
//        public int LawyerID { get; set; }
//        public string LawyerName { get; set; }
//        public string ClaimantFirstName { get; set; }
//        public string ClaimantLastName { get; set; }
//        public int ProvinceID { get; set; }
//        public string ProvinceName { get; set; }
//        public DateTime LossDate { get; set; }
//        public int LitigationState { get; set; }
//        public string LitigationName { get; set; }
//        public int? SubClaimType { get; set; }
//        public int ClaimID { get; set; }
//        public string SubClaimName { get; set; }
//        public string ClaimName { get; set; }
//        public string ActionType { get; set; }
//        public string ActionTypeName { get; set; }
//        public string PolicyHolderClientNo { get; set; }
//        public string PolicyHolderRefNo { get; set; }
//        public int? FirmID { get; set; }
//        public int StatusID { get; set; }
//        public string Status { get; set; }
//        public DateTime? StatementDate { get; set; }
//        public bool IsActive { get; set; }
//        public int IsApproved { get; set; }
//        public string ApprovalMessage { get; set; }
//        public string InternalNotes { get; set; }
//        public int? AddedByLisc { get; set; }
//        public int? AddedByFirm { get; set; }
//        public string FirmName { get; set; }
//        public string CaseStatus { get; set; }
//        public string InsurerName { get; set; }
//        public DateTime? TrialDate { get; set; }       
//        public decimal LimitAmount { get; set; }
//        public int OldStatus { get; set; }
//        public int? SupportingStatusID { get; set; }
//        public string SupporingText { get; set; }
//        public string SupportingType { get; set; }
//        public string StandardLimit { get; set; }
//        public decimal StandardLimitRate { get; set; }
//        public string SupplementalLimit { get; set; }
//        public decimal SuplementalRate { get; set; }
//        public string SuplementalPlusLimit { get; set; }
//        public decimal SuplementalPlusRate { get; set; }
//        public bool IsSupplementalReq { get; set; }
//        public bool IsSupplementalPlusReq { get; set; }
//        public bool IsCaseTransfered { get; set; }
//        public bool IsTrialCommenced { get; set; }
//        public decimal MaxSupplemental { get; set; }
//        public HttpPostedFileBase[] CaseFiles { get; set; }
//        //public List<CaseFileModel> CaseFileList { get; set; }
//        public string RedStandardLimit { get; set; }
//        public List<int> RedStandardType { get; set; }
//        public bool IsPostPreTrialReq { get; set; }
//        public bool IsPostPreTrialDone { get; set; }

//        public string AppliedProduct { get; set; }
//        public string PreviousProduct { get; set; }
//        public string Products { get; set; }
//        public CaseDetailsModel() {
        
//        }
//        public int[] ActionTypeIds { get; set; }
//        public CaseDetailsModel(CaseDetail obj)
//        {
//            this.ActionType = obj.ActionType;
//            //this.ActionTypeName = obj.ActionTypes.Name;
//            this.ClaimantFirstName = obj.ClaimantFirstName;
//            this.ClaimantLastName = obj.ClaimantLastName;
//            if (obj.Claims != null)
//            {
//               // this.ClaimName = obj.Claims.Name;
//            }
//            this.Id = obj.Id;
//            this.LawyerID = obj.LawyerID;
//           // this.LawyerName = obj.Lawyers.FirstName + " " + obj.Lawyers.LastName;
//            this.LiscRefrenceID = obj.LiscRefrenceID;
//            this.LitigationName = obj.LitigationStage.Name;
//            this.LitigationState = obj.LitigationState;
//            this.LossDate = obj.LossDate;
//            this.PolicyHolderClientNo = obj.PolicyHolderClientNo;
//            this.PolicyHolderRefNo = obj.PolicyHolderRefNo;
//            this.ProvinceID = obj.ProvinceID;
//            this.ProvinceName = obj.Province.Name;
//            this.SubClaimName = obj.ClaimType != null ? obj.ClaimType.Name : "";
//            this.SubClaimType = obj.SubClaimType;
//            this.FirmID = obj.FirmID;
//            this.StatusID = obj.Status;
//            this.Status = UtilitiesHelp.EnumToDecription(typeof(ApprovalStatus), obj.IsApproved);
//            this.StatementDate = obj.StatementDate;
//            this.IsActive = obj.IsActive;
//            this.IsApproved = obj.IsApproved;
//            this.ClaimID = obj.ClaimID;
//            this.ApprovalMessage = obj.ApprovalMessage;
//            this.AddedByFirm = obj.AddedByFirm;
//            this.AddedByLisc = obj.AddedByLisc;
//            this.InternalNotes = obj.InternalNotes;
//            this.IsTrialCommenced = obj.IsTrialCommenced;
//            if (obj.Firm != null)
//            {
//                this.FirmName = obj.Firm.FirmName;
//            }
                      
//            this.TrialDate = obj.TrialDate;
//            this.InsurerName = obj.InsurerName;
//            //if (obj.CaseFiles != null && obj.CaseFiles.Count() > 0)
//            //{
//            //    this.CaseFileList = obj.CaseFiles.Select(x => new CaseFileModel(x, obj.FirmID ?? 0)).ToList();
//            //}
//            this.SupporingText = obj.SupporingText;
//            this.SupportingStatusID = obj.SupportingStatusID;
//            this.OldStatus = obj.OldStatus;
//            this.SuplementalPlusLimit = obj.SuplementalPlusLimit;
//            this.SuplementalPlusRate = obj.SuplementalPlusRate;
//            this.SuplementalRate = obj.SuplementalRate;
//            this.SupplementalLimit = obj.SupplementalLimit;
//            this.StandardLimit = obj.StandardLimit;
//            this.StandardLimitRate = obj.StandardLimitRate;
//            this.IsCaseTransfered = obj.IsCaseTransfered;
//            this.AppliedProduct = obj.AppliedProduct;
//            this.PreviousProduct = obj.PreviousProduct;
//            this.Products = obj.Products;
//            this.IsPostPreTrialReq = obj.IsPostPreTrialReq;
//            this.IsPostPreTrialDone = obj.IsPostPreTrialDone;
//        }
//    }

//    public class ExcelCaseModel
//    {
//        public int Id { get; set; }
//        public int LawyerID { get; set; }
//        public string LawyerName { get; set; }
//        public string ClaimantFirstName { get; set; }
//        public string ClaimantLastName { get; set; }
//        public int ProvinceID { get; set; }
//        public string ProvinceName { get; set; }
//        public DateTime LossDate { get; set; }
//        public int LitigationState { get; set; }
//        public string LitigationName { get; set; }
//        public int SubClaimType { get; set; }
//        public int ClaimID { get; set; }
//        public string SubClaimName { get; set; }
//        public string ClaimName { get; set; }
//        public int ActionType { get; set; }
//        public string ActionTypeName { get; set; }
//        public string PolicyHolderClientNo { get; set; }
//        public string PolicyHolderRefNo { get; set; }
//        public int? FirmID { get; set; }
//        public int? AddedByLisc { get; set; }
//        public int? AddedByFirm { get; set; }
//        public int StatusID { get; set; }
//        public string Status { get; set; }
//        public DateTime StatementDate { get; set; }
//        public bool IsActive { get; set; }
//        public bool IsApproved { get; set; }
//        public string InsurerName { get; set; }
//        public DateTime? TrialDate { get; set; }
//        public int? LimitRequest { get; set; }
//        public decimal LimitAmount { get; set; }
//        public string LimitRequestName { get; set; }
//        public List<SelectListItem> LawyerList { get; set; }
//        public List<SelectListItem> ProvinceList { get; set; }
//        public List<SelectListItem> LitigationList { get; set; }
//        public List<SelectListItem> ClaimList { get; set; }
//        public List<SelectListItem> ActionList { get; set; }
//        public List<SelectListItem> SubClaimList { get; set; }
//        public List<SelectListItem> LimitRequestList { get; set; }
//    }

//    public class ApprovalModel
//    {
//        public int Id { get; set; }
//        public int FirmId { get; set; }
//        public int ApprovalId { get; set; }
//        public string ApprovalMessage { get; set; }
//        public string InternalNotes { get; set; }
//        public string SupplementalPlusRate { get; set; }
//        public bool ShowSupplemental { get; set; }

//        public string SupplementalRate { get; set; }
//        public bool ShowSupplementalRate { get; set; }

//        public string StandardRate { get; set; }
//        public HttpPostedFileBase StandardRateApproval { get; set; }
//        public HttpPostedFileBase SupplementalRateApproval { get; set; }
//    }

//    public class ExportExcelModel
//    {
//        public List<ExcelCaseModel> CaseModel { get; set; }
//    }
//}
