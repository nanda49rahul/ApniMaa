using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace ApniMaa.BLL.Common
{
    public static class Config
    {
        public static bool LogExceptionInDatabase
        {
            get { return Boolean.Parse(System.Configuration.ConfigurationManager.AppSettings["LogExceptionInDB"].ToString()); }
        }
        public static string ApniMaaSecretKey
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["ApniMaaSecretKey"]; }
        }
        public static string AzureSubscriptionId
        {
            get { return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["AzureSubscriptionId"]); }
        }
        public static string Location
        {
            get { return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["Location"]); }
        }
        public static string Edition
        {
            get { return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["Edition"]); }

        }
        public static string RequestedServiceObjectName
        {
            get { return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["RequestedServiceObjectName"]); }
        }
        public static string ResourceGroupName
        {
            get { return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["ResourceGroupName"]); }
        }
        public static string ServerName
        {
            get { return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["ServerName"]); }
        }
        public static string DomainName
        {
            get { return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["DomainName"]); }
        }
        public static string ClientId
        {
            get { return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["ClientId"]); }
        }
        public static string ClientAppUri
        {
            get { return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["ClientAppUri"]); }
        }

        public static string AdminEmail
        {
            get { return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["AdminEmail"]); }
        }
        public static string BaseUrl
        {
            get { return ConfigurationManager.AppSettings["BaseUrl"].ToString(); }
        }
        public static string FirmUrl
        {
            get { return ConfigurationManager.AppSettings["FirmUrl"].ToString(); }
        }

        private static IKernel _kernel;
        public const string EncryptionKey = "&$&%^$&^%$^%hjgkjhgkjhg%$%*&&(*^*76987";
        public static void SetKernel(IKernel kernel)
        {
            _kernel = kernel;
        }
        public static T Get<T>(string name = "")
        {
            return string.IsNullOrEmpty(name) ? _kernel.Get<T>() : _kernel.Get<T>(name);
        }

        public static TResult IfNotNull<TInput, TResult>(this TInput obj, Func<TInput, TResult> expression) where TInput : class
        {
            if (obj == null || expression == null) return default(TResult);
            var value = expression(obj);
            return value;
        }

    }

    public static class PayPalConfiguration
    {
        public readonly static string ClientId;
        public readonly static string ClientSecret;

        static PayPalConfiguration()
        {
            var config = GetConfig();
            ClientId = config["clientId"];
            ClientSecret = config["clientSecret"];
        }
        public static Dictionary<string, string> GetConfig()
        {
            var cc = PayPal.Api.ConfigManager.Instance.GetProperties();
            cc.Add("content-type", "application/json");
            return cc;
        }
        
        private static string GetAccessToken()
        {
            // getting accesstocken from paypal                
            string accessToken = new OAuthTokenCredential
        (ClientId, ClientSecret, GetConfig()).GetAccessToken();

            return accessToken;
        }

        public static APIContext GetAPIContext()
        {
            // return apicontext object by invoking it with the accesstoken
            APIContext apiContext = new APIContext(GetAccessToken());
            apiContext.Config = GetConfig();
            return apiContext;
        }
        public static Dictionary<string, string> GetAcctAndConfig()
        {
            Dictionary<string, string> configMap = new Dictionary<string, string>();
            configMap = GetConfig();
            configMap.Add("account1.apiUsername", "kumar.life74-facilitator_api1.gmail.com");
            configMap.Add("account1.apiPassword", "U6YL7HV5QQ2SZV5U");
            configMap.Add("account1.apiSignature", "AFcWxV21C7fd0v3bYYYRCpSSRl31AOzxmb0WHisTP06urC.JtPAAFhty");
            configMap.Add("account1.applicationId", "APP-80W284485P519543T");
            configMap.Add("sandboxEmailAddress", "kumar.life74-facilitator@gmail.com");
            return configMap;
        }
    }
}
