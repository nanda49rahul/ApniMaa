using ApniMaa.Framework.Api.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ApniMaa.Framework.Api.Logging
{
    public class ApiLogger : DelegatingHandler
    {
        protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            // Extract the request logging information
            //var requestLoggingInfo = ExtractLoggingInfoFromRequest(request);

            // Execute the request, this does not block
            var response = base.SendAsync(request, cancellationToken);

            // Log the incoming data to the database
            //WriteLoggingInfo(requestLoggingInfo);
            //

            // Once the response is processed asynchronously, log the response data
            // to the database
            response.ContinueWith((responseMsg) =>
            {
                // Extract the response logging info then persist the information
                //var responseLoggingInfo = ExtractResponseLoggingInfo(requestLoggingInfo, responseMsg.Result);
                //Logger.Log(responseLoggingInfo);
            });
            return response;
        }

        const string TOKEN_NAME = "X-Token";
        //private ApiLogModel ExtractLoggingInfoFromRequest(HttpRequestMessage request)
        //{
        //    var info = new ApiLogModel();
        //    info.HttpMethod = request.Method.Method;
        //    info.Url = request.RequestUri.AbsolutePath;
        //    info.IPAddress = HttpContext.Current != null ? HttpContext.Current.Request.UserHostAddress : "0.0.0.0";
        //    info.Data = request.RequestUri.Query;
        //    info.CreatedOn = DateTime.Now;
        //    if (request.Headers.Contains(TOKEN_NAME))
        //    {
        //        string encryptedToken = request.Headers.GetValues(TOKEN_NAME).First();
        //        try
        //        {
        //            info.Token = Token.Decrypt(encryptedToken).ToString();
        //        }
        //        catch { info.Token = "Error while decryption : " + encryptedToken; }
        //    }

        //    return info;
        //}

        //private ApiLogModel ExtractResponseLoggingInfo(ApiLogModel with,HttpResponseMessage result)
        //{

        //    if (result.StatusCode == System.Net.HttpStatusCode.OK)
        //    { }
        //    return with;
        //}
    }
}
