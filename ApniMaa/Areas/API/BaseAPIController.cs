using ApniMaa.Attributes;
using ApniMaa.BLL.Managers;
using ApniMaa.BLL.Models;
using ApniMaa.Framework.Api;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Linq;

namespace ApniMaa.Areas.API
{
    [HandelException, CheckAuthorization, ValidateModel, NoCache]
    public class BaseAPIController : ApiController
    {
        public UserModel LOGGED_IN_USER { get; set; }
        public string Token { get; set; }

        #region Json Result Methods

        protected HttpResponseMessage CreateResponseSuccess(string message, object model = null)
        {
            return Request.CreateResponse<ApiActionOutput>(HttpStatusCode.OK, new ApiActionOutput
            {
                Status = Status.Success,
                Message = message,
                result = model,
            });


        }

        protected HttpResponseMessage CreateResponseError(string message)
        {
            return Request.CreateResponse<ApiActionOutput>(HttpStatusCode.OK, new ApiActionOutput
            {
                Status = Status.Failed,
                Message = message
            });
        }

        protected HttpResponseMessage CreateResponseError(string message, ActionStatus status, object model = null)
        {
            return Request.CreateResponse<ApiActionOutput>(HttpStatusCode.OK, new ApiActionOutput
            {
                Status = Status.Failed,
                Message = message,
                result = model
            });
        }
        protected T BindFiles<T>(T model)
        {
            var props = model.GetType().GetProperties().Where(p => p.PropertyType == typeof(HttpPostedFileBase));
            foreach (var prop in props)
            {
                if (HttpContext.Current.Request.Files[prop.Name] != null)
                {
                    prop.SetValue(model, ((HttpPostedFileBase)new HttpPostedFileWrapper(HttpContext.Current.Request.Files[prop.Name])));
                }
            }
            return model;
        }

        #endregion
    }
}