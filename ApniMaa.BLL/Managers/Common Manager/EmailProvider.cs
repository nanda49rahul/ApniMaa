using ApniMaa.BLL.Interfaces;
using ApniMaa.BLL.Models;
using ApniMaa.DAL;
using HandlebarsDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ApniMaa.BLL.Managers.Common_Managers
{
    public class EmailProvider : BaseManager , IEmailProvider
    {
        
        ////private readonly IEmailTemplateManager templateManager;
        //private readonly SmtpClient smtpClient = null;
        //private bool disposed = false;

        //private EmailProvider()
        //{
        //    smtpClient = new SmtpClient();
        //}

        ////public EmailProvider(/*IEmailTemplateManager templateManager*/)
        ////    : this()
        ////{
        ////    //this.templateManager = templateManager;
        ////}

        //public EmailProvider(string smtpAddress, int portNumber, string userName, string password)
        //{
        //    smtpClient = new SmtpClient(smtpAddress, portNumber);
        //    smtpClient.Credentials = new NetworkCredential(userName, password);
        //}

        //public void Send(MailMessage message)
        //{

        //    if (disposed) throw new ObjectDisposedException("Email Provider not able to send email after dispose");

        //    if (message == null) throw new ArgumentNullException("Email message argument can't be null");

        //    if (message.To == null || !message.To.Any()) throw new Exception("Recipients are not specified");

        //    var recipientList = string.Join(",", message.To.Select(x => x.Address).ToArray());
        //    try
        //    {
        //        smtpClient.Send(message);
        //    }
        //    catch (Exception ex)
        //    {
                 
        //    }
        //}

        //public void Send(string to, string subject, string body = "", bool isHtml = true, string from = "", string attachment = "", string cc = "")
        //{
        //    if (String.IsNullOrEmpty(to) && String.IsNullOrEmpty(subject))
        //        throw new Exception("Recipient or subject can't be null or empty");
        //    var mailMessage = new MailMessage();
        //    var toEmail = new MailAddress(to);
        //    mailMessage.To.Add(toEmail);
        //    if (!string.IsNullOrEmpty(cc))
        //    {
        //        mailMessage.CC.Add(string.Join(",", cc.Split(',').Select(x => x).ToArray()));
        //    }
        //    mailMessage.Subject = subject;
        //    mailMessage.Body = body;
        //    if (!string.IsNullOrEmpty(attachment))
        //    {
        //        mailMessage.Attachments.Add(new Attachment(attachment));
        //    }
        //    mailMessage.IsBodyHtml = isHtml;
        //    this.Send(mailMessage);
        //}
        //public void SendMultipleAttachment(string to, string subject, string body = "", bool isHtml = true, string from = "", string attachment = "", string cc = "")
        //{
        //    if (String.IsNullOrEmpty(to) && String.IsNullOrEmpty(subject))
        //        throw new Exception("Recipient or subject can't be null or empty");
        //    var mailMessage = new MailMessage();
        //    var toEmail = new MailAddress(to);
        //    mailMessage.To.Add(toEmail);
        //    if (!string.IsNullOrEmpty(cc))
        //    {
        //        mailMessage.CC.Add(string.Join(",", cc.Split(',').Select(x => x).ToArray()));
        //    }
        //    mailMessage.Subject = subject;
        //    mailMessage.Body = body;
        //    if (!string.IsNullOrEmpty(attachment))
        //    {
        //        var attachments=attachment.Split(',');
        //        foreach (var item in attachments)
        //        {
        //            mailMessage.Attachments.Add(new Attachment(item));   
        //        }
        //    }
        //    mailMessage.IsBodyHtml = isHtml;
        //    this.Send(mailMessage);
        //}
        ////public void Send(string to, string Subject, TemplateTypes type, object bindableContext, string cc, string from = "", string attachment = "")
        ////{
        ////    if (type == 0)
        ////        throw new ArgumentNullException("Specify the valid template type");
        ////    var content = templateManager.GetTemplateByType(type);
        ////    if (content == null)
        ////        throw new Exception(String.Format("No {0} Template exist in system", type.ToString()));
        ////    var subjectBindableFunc = Handlebars.Compile(content.EmailSubject);
        ////    var bodyBindableFunc = Handlebars.Compile(content.TemplateContent);
        ////    Send(to: to, subject: subjectBindableFunc(bindableContext), body: bodyBindableFunc(bindableContext), from: from, attachment: attachment,cc:cc);
        ////}


        //public void Send(string to, string subject, string body = "", Attachment attachment=null)
        //{
        //    if (String.IsNullOrEmpty(to) && String.IsNullOrEmpty(subject))
        //        throw new Exception("Recipient or subject can't be null or empty");
        //    var mailMessage = new MailMessage();
        //    var toEmail = new MailAddress(to);
        //    mailMessage.To.Add(toEmail);           
        //    mailMessage.Subject = subject;
        //    mailMessage.Body = body;
        //    if (attachment!=null)
        //    {
        //        mailMessage.Attachments.Add(attachment);
        //    }
        //    this.Send(mailMessage);
        //}

        //private void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        if (!disposed)
        //        {
        //            if (smtpClient != null)
        //                smtpClient.Dispose();
        //            disposed = true;
        //        }
        //    }
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //~EmailProvider()
        //{
        //    Dispose(false);
        //}


    }
}
