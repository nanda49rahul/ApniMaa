using ApniMaa.BLL.Interfaces;
using ApniMaa.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using ApniMaa.DAL;
using ApniMaa.BLL.Common;

namespace ApniMaa.BLL.Managers
{
    public class EmailTemplateManager : BaseManager, IEmailTemplateManager
    {

        //PagingResult<TemplateViewModel> IEmailTemplateManager.GetEmailTemplateList(PagingModel model)
        //{
        //    var result = new PagingResult<TemplateViewModel>();
        //    var query = Context.EmailTemplates.OrderBy(model.SortBy + " " + model.SortOrder);
        //    if (!string.IsNullOrEmpty(model.Search))
        //    {
        //        query = query.Where(z => z.TemplateName.Contains(model.Search));
        //    }
        //    var list = query
        //       .Skip(model.PageNo - 1).Take(model.RecordsPerPage)
        //       .ToList().Select(x => new TemplateViewModel(x)).ToList();
        //    result.List = list;
        //    result.Status = ActionStatus.Successfull;
        //    result.Message = "Template List";
        //    result.TotalCount = query.Count();
        //    return result;
        //}

        //ActionOutput IEmailTemplateManager.AddUpdateEmailTemplate(AddEditEmailTemplateModel templateModel)
        //{
        //    var existingTemplate = Context.EmailTemplates.FirstOrDefault(z => z.TemplateId == templateModel.TemplateId);
        //    if (existingTemplate == null)
        //    {
        //        Context.EmailTemplates.Add(new EmailTemplate
        //        {
        //            TemplateName = templateModel.TemplateName,
        //            EmailSubject = templateModel.EmailSubject,
        //            TemplateContent = templateModel.TemplateContent,
        //            TemplateStatus = templateModel.TemplateStatus,
        //            CreatedOn = DateTime.UtcNow,
        //            TemplateType = templateModel.TemplateType
        //        });
        //        Context.SaveChanges();
        //        return new ActionOutput
        //        {
        //            Status = ActionStatus.Successfull,
        //            Message = "Template Added Sucessfully."
        //        };
        //    }
        //    else
        //    {
        //        existingTemplate.EmailSubject = templateModel.EmailSubject;
        //        existingTemplate.TemplateContent = templateModel.TemplateContent;
        //        existingTemplate.TemplateStatus = templateModel.TemplateStatus;
        //        existingTemplate.UpdatedOn = DateTime.UtcNow;
        //        existingTemplate.TemplateType = templateModel.TemplateType;
        //        Context.SaveChanges();
        //        return new ActionOutput
        //        {
        //            Status = ActionStatus.Successfull,
        //            Message = "Template Updated Sucessfully."
        //        };
        //    }
        //}

        //AddEditEmailTemplateModel IEmailTemplateManager.GetEmailTemplateByTemplateId(int templateId)
        //{
        //    var existingTemplate = Context.EmailTemplates.FirstOrDefault(z => z.TemplateId == templateId);
        //    if (existingTemplate != null)
        //        return new AddEditEmailTemplateModel(existingTemplate);
        //    else
        //        return null;
        //}

        ////void IEmailTemplateManager.ForgotPassword(UserModel model, string OTPCode)
        ////{
        ////    var fullName = model.FirstName;
        ////    var url = Config.BaseUrl + AppDefaults.AdminResetPasswordUrl + OTPCode;
        ////    var emailtemplate = GetEmailTemplate((int)TemplateTypes.ForgetPassword,true);
        ////    emailtemplate.TemplateContent = emailtemplate.TemplateContent.Replace(EmailConstants.UserName, fullName);
        ////    emailtemplate.TemplateContent = emailtemplate.TemplateContent.Replace(EmailConstants.ForgotPasswordLink, url);

        ////    Utilities.SendEmailAsync(emailtemplate, model.Email);
        ////}

        //#region Helping Methods

        //public AddEditEmailTemplateModel GetEmailTemplate(int templateType, bool isAddHeaderFooter = false)
        //{
        //    var existingTemplate = Context.EmailTemplates.FirstOrDefault(z => z.TemplateType == templateType);
        //    if (existingTemplate != null)
        //    {

        //        var headerTemplateContent = Context.EmailTemplates.FirstOrDefault(z => z.TemplateType == (int)TemplateTypes.EmailHeader);
        //        var footerTemplateContent = Context.EmailTemplates.FirstOrDefault(z => z.TemplateType == (int)TemplateTypes.EmailFooter);

        //        var emailtemplate = new AddEditEmailTemplateModel(existingTemplate);

        //        if (isAddHeaderFooter)
        //        {
        //            emailtemplate.TemplateContent = emailtemplate.TemplateContent.Replace(EmailConstants.HeaderTemplate, headerTemplateContent.TemplateContent);
        //            emailtemplate.TemplateContent = emailtemplate.TemplateContent.Replace(EmailConstants.FooterTemplate, footerTemplateContent.TemplateContent);
        //        }
        //        return emailtemplate;
        //    }
        //    else
        //        return null;
        //}
        //#endregion
    }
}
