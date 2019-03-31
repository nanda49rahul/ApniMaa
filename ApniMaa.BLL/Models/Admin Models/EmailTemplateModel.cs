//using ApniMaa.BLL.Common;;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web.Mvc;
//using ApniMaa.DAL;

//namespace ApniMaa.BLL.Models
//{
//    public class TemplateViewModel
//    {
//        public int TemplateId { get; set; }
//        public string TemplateName { get; set; }
//        public DateTime CreatedOn { get; set; }
//        public bool TemplateStatus { get; set; }
//        public TemplateTypes TemplateType { get; set; }
//        public TemplateViewModel()
//        {

//        }

//        internal TemplateViewModel(EmailTemplate emailTemplate)
//        {
//            this.TemplateId = emailTemplate.TemplateId;
//            this.TemplateName = emailTemplate.TemplateName;
//            this.CreatedOn = emailTemplate.CreatedOn;
//            this.TemplateStatus = emailTemplate.TemplateStatus;
//            this.TemplateType = (TemplateTypes)emailTemplate.TemplateType;
//        }
//    }

//    public class AddEditEmailTemplateModel
//    {
//        public int TemplateId { get; set; }

//        [Required(ErrorMessage = "*Required")]
//        public string TemplateName { get; set; }

//        [AllowHtml, Required(ErrorMessage = "*Required")]
//        public string EmailSubject { get; set; }

//        [AllowHtml, Required(ErrorMessage = "*Required")]
//        public string TemplateContent { get; set; }

//        public bool TemplateStatus { get; set; }

//        [Required(ErrorMessage = "*Required")]
//        public int TemplateType { get; set; }

//        public List<SelectListItem> TemplateTypeList { get; set; }
//        public AddEditEmailTemplateModel()
//        {
//            this.TemplateStatus = true;
//            this.TemplateTypeList = new List<SelectListItem>();
//            this.TemplateTypeList = UtilitiesHelp.EnumToList(typeof(TemplateTypes));
//        }

//        internal AddEditEmailTemplateModel(EmailTemplate emailTemplate)
//        {
//            this.TemplateId = emailTemplate.TemplateId;
//            this.TemplateName = emailTemplate.TemplateName;
//            this.EmailSubject = emailTemplate.EmailSubject;
//            this.TemplateContent = emailTemplate.TemplateContent;
//            this.TemplateType = emailTemplate.TemplateType;
//            this.TemplateStatus = emailTemplate.TemplateStatus;
//            this.TemplateTypeList = new List<SelectListItem>();
//            this.TemplateTypeList = UtilitiesHelp.EnumToList(typeof(TemplateTypes));
//        }
//    }

//    public class MergingTags
//    {
//        public string Link { get; set; }
//        public string Name { get; set; }
//        public string Password { get; set; }
//        public string ClientName { get; set; }
//        public string FacilityName { get; set; }
//        public string ReferringClient { get; set; }
//        public string UserName { get; set; }
//        public string Pin { get; set; }
//        public string Task { get; set; }
//        public string Created_user { get; set; }
//        public string Created_date { get; set; }
//        public string End_date { get; set; }
//        public string TaskTitle { get; set; }
//        public string CompletedBy { get; set; }
//        public string CompletedOn { get; set; }
//        public string SessionDateTime { get; set; }
//        public string Trainer { get; set; }
//        public string ClickHere { get; set; }
//        public string NoOfSession { get; set; }
//        public string RenewNow { get; set; }
//        public string ServiceName { get; set; }
//        public string Amount { get; set; }
//        public string PaymentDate { get; set; }
//        public string AgreementId { get; set; }
//        public string ScheduledPaymentDate { get; set; }
//        public string EmailContent { get; set; }
//        public string Email { get; set; }
//        public string FacilityLogo { get; set; }
//        public string FacilityAddress { get; set; }
//        public string PlanName { get; set; }
//        public string Imageurl { get; set; }
//        public string Phone { get; set; }
//        public string Subject { get; set; }
//        public string Request { get; set; }
//    }
//}
