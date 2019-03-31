using ApniMaa.BLL.Common;
using ApniMaa.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ApniMaa.BLL.Models
{
    //public class TemplateViewModel
    //{
    //    public int TemplateId { get; set; }
    //    public string TemplateName { get; set; }
    //    public DateTime CreatedOn { get; set; }
    //    public bool TemplateStatus { get; set; }
    //    public TemplateTypes TemplateType { get; set; }
    //    public TemplateViewModel()
    //    {

    //    }

    //    internal TemplateViewModel(EmailTemplate emailTemplate)
    //    {
    //        this.TemplateId = emailTemplate.TemplateId;
    //        this.TemplateName = emailTemplate.TemplateName;
    //        this.CreatedOn = emailTemplate.CreatedOn;
    //        this.TemplateStatus = emailTemplate.TemplateStatus;
    //        this.TemplateType = (TemplateTypes)emailTemplate.TemplateType;
    //    }
    //}

    //public class AddEditEmailTemplateModel
    //{
    //    public int TemplateId { get; set; }

    //    [Required(ErrorMessage = "*Required")]
    //    public string TemplateName { get; set; }

    //    [AllowHtml, Required(ErrorMessage = "*Required")]
    //    public string EmailSubject { get; set; }

    //    [AllowHtml, Required(ErrorMessage = "*Required")]
    //    public string TemplateContent { get; set; }

    //    public bool TemplateStatus { get; set; }

    //    [Required(ErrorMessage = "*Required")]
    //    public int TemplateType { get; set; }

    //    public List<SelectListItem> TemplateTypeList { get; set; }
    //    public AddEditEmailTemplateModel()
    //    {
    //        this.TemplateStatus = true;
    //        this.TemplateTypeList = new List<SelectListItem>();
    //        this.TemplateTypeList = Utilities.EnumToList(typeof(TemplateTypes));
    //    }

    //    internal AddEditEmailTemplateModel(EmailTemplate emailTemplate)
    //    {
    //        this.TemplateId = emailTemplate.TemplateId;
    //        this.TemplateName = emailTemplate.TemplateName;
    //        this.EmailSubject = emailTemplate.EmailSubject;
    //        this.TemplateContent = emailTemplate.TemplateContent;
    //        this.TemplateType = emailTemplate.TemplateType;
    //        this.TemplateStatus = emailTemplate.TemplateStatus;
    //        this.TemplateTypeList = new List<SelectListItem>();
    //        this.TemplateTypeList = Utilities.EnumToList(typeof(TemplateTypes));
    //    }
    //}

    public class TemplateViewModel
    {
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool TemplateStatus { get; set; }
        public TemplateTypes TemplateType { get; set; }
        public TemplateViewModel()
        {

        }

        internal TemplateViewModel(EmailTemplate emailTemplate)
        {
            this.TemplateId = emailTemplate.TemplateId;
            this.TemplateName = emailTemplate.TemplateName;
            this.CreatedOn = emailTemplate.CreatedOn;
            this.TemplateStatus = emailTemplate.TemplateStatus;
            this.TemplateType = (TemplateTypes)emailTemplate.TemplateType;
        }
    }

    public class AddEditEmailTemplateModel
    {
        public int TemplateId { get; set; }

        [Required(ErrorMessage = "*Required")]
        public string TemplateName { get; set; }

        [AllowHtml, Required(ErrorMessage = "*Required")]
        public string EmailSubject { get; set; }

        [AllowHtml, Required(ErrorMessage = "*Required")]
        public string TemplateContent { get; set; }

        public bool TemplateStatus { get; set; }

        [Required(ErrorMessage = "*Required")]
        public int TemplateType { get; set; }

        public List<SelectListItem> TemplateTypeList { get; set; }

        public string AttachmentUrl { get; set; }
        public AddEditEmailTemplateModel()
        {
            this.TemplateStatus = true;
            this.TemplateTypeList = new List<SelectListItem>();
            this.TemplateTypeList = UtilitiesHelp.EnumToList(typeof(TemplateTypes));
        }

        internal AddEditEmailTemplateModel(EmailTemplate emailTemplate)
        {
            this.TemplateId = emailTemplate.TemplateId;
            this.TemplateName = emailTemplate.TemplateName;
            this.EmailSubject = emailTemplate.EmailSubject;
            this.TemplateContent = emailTemplate.TemplateContent;
            this.TemplateType = emailTemplate.TemplateType;
            this.TemplateStatus = emailTemplate.TemplateStatus;
            this.TemplateTypeList = new List<SelectListItem>();
            this.TemplateTypeList = UtilitiesHelp.EnumToList(typeof(TemplateTypes));
        }
    }

    public class HeaderFooterPageModel
    {
        public int Id { get; set; }
        public int Type { get; set; }
        [AllowHtml]
        public string PageContent { get; set; }

        public HeaderFooterPageModel()
        {

        }
    }


    public class Imagesviewmodel
    {
        public string Url { get; set; }
    }
}
