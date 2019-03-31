//using ApniMaa.BLL.Common;;
// 
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ApniMaa.DAL;

//namespace ApniMaa.BLL.Models
//{
//    public class ContactModel
//    {
//        public int Id { get; set; }
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public int ContactRole { get; set; }
//        public string PhoneNumber { get; set; }
//        public string Email { get; set; }
//        public string Title { get; set; }
//        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password should be minimum of 6 and maximum of 20 characters.")]
//        public string Password { get; set; }
//        [Compare("Password", ErrorMessage = "Password and Confirm Password does not match")]
//        public string ConfirmPassword { get; set; }
//        public int BranchID { get; set; }
//        public string YearOfCall { get; set; }
//        public int[] ProvinceID { get; set; }
//        public string ProvinceName { get; set; }
//        public string RoleName { get; set; }
//        public int? FirmID { get; set; }
//        public string BranchName { get; set; }
//        public DateTime CreatedDate { get; set; }
//        public bool IsActive { get; set; }
//        public int IsApproved { get; set; }
//        public string ApprovalMessage { get; set; }
//        public string InternalNotes { get; set; }
//        public int? AddedByLisc { get; set; }
//        public int? AddedByFirm { get; set; }
//        public string Status { get; set; }
//        public string FirmName { get; set; }
//        public ContactModel() { }
//        public ContactModel(ContactMaster model)
//        {
//            this.BranchID = model.BranchID??0;
//            this.ContactRole = model.ContactRole;
//            this.Email = model.Email;
//            this.FirstName = model.FirstName;
//            this.Id = model.Id;
//            this.LastName = model.LastName;
//            this.Password = EncryptionHelper.DecryptFromByte(model.Password);
//            this.PhoneNumber = model.PhoneNumber;
//            this.CreatedDate = model.CreatedDate;
//            this.Title = model.Title;
//            this.YearOfCall = model.YearOfCall;
//            var contactProvsion = model.ContactProvisions.Where(x => x.ContactID == model.Id);
//            if (contactProvsion!=null &&  contactProvsion.Any())
//            {
//                this.ProvinceID = contactProvsion.Select(x => x.ProvinceID).ToArray();
//                var provineNames = contactProvsion.Select(x => x.Province.Name).ToArray();
//                this.ProvinceName = string.Join(",", provineNames);
//            }
//            if (model.BranchID != null && model.BranchID > 0)
//            {
//                this.BranchName = model.BranchMaster.BranchName;
//            }
//            this.IsActive = model.IsActive;
//            this.FirmID = model.FirmID;
//            this.IsApproved = model.IsApproved;
//            this.RoleName = UtilitiesHelp.EnumToDecription(typeof(ContactRole),model.ContactRole);
//            this.ApprovalMessage = model.ApprovalMessage;
//            this.InternalNotes = model.InternalNotes;
//            this.AddedByFirm = model.AddedByFirm;
//            this.AddedByLisc = model.AddedByLisc;
//            this.ConfirmPassword = this.Password;
//            this.Status = UtilitiesHelp.EnumToDecription(typeof(ApprovalStatus), model.IsApproved);
//            //if (model.Prospects != null)
//            //{
//            //    this.FirmName = model.Prospects.FleetName;
//            //}
//        }
//    }

//    public class LawyerViewModel
//    {
//        public int LawyerID { get; set; }
//        public string LawyerName { get; set; }
//        public int CaseWon { get; set; }
//        public int RunningCase { get; set; }

//        public LawyerViewModel() { }

//        public LawyerViewModel(ContactMaster obj)
//        {
//            this.LawyerID = obj.Id;
//            this.LawyerName = obj.FirstName + " " + obj.LastName;
//            this.CaseWon = obj.CaseDetails.Where(x => x.Status == (int)CaseStatus.FilesSettled).Count();
//            this.RunningCase = obj.CaseDetails.Where(x => x.Status != (int)CaseStatus.FilesSettled).Count();
//        }
//    }
//}
