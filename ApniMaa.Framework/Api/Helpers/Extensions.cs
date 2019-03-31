using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Net;
using ApniMaa.Framework.Api;

namespace ApniMaa.Framework.Api.Helpers
{
    public static class Extensions
    {
        public static string GetClientIP(this HttpRequestMessage request)
        {
            return ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
        }

        public static Dictionary<string, string> ToDictionary(this string keyValue)
        {
            return keyValue.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                          .Select(part => part.Split('='))
                          .ToDictionary(split => split[0], split => split[1]);
        }

        public static HttpResponseMessage ConvertToHttpResponseOK(this JsonContent content)
        {
            return content.ConvertToHttpResponse(HttpStatusCode.OK);
        }

        public static HttpResponseMessage ConvertToHttpResponseISE(this JsonContent content)
        {
            return content.ConvertToHttpResponse(HttpStatusCode.InternalServerError);
        }

        public static HttpResponseMessage ConvertToHttpResponse(this JsonContent content, HttpStatusCode status)
        {
            return new HttpResponseMessage()
            {
                StatusCode = status,
                Content = content
            };
        }

        public static string RemoveSpecialChars(this string value)
        {
            var str = "ok";
            return value.Replace("%20", " ");
        }



    }
}
