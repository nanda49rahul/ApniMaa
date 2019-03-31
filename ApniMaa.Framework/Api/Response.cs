using Newtonsoft.Json;
using ApniMaa.BLL.Models;

namespace ApniMaa.Framework.Api
{
    public class Response
    {
        public int Status { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public dynamic result { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string token { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public char? verified { get; set; }

    }

    public class Status
    {
      public static int Success = 201;
      public static int SessionExpired = 203;
      public static  int Failed = 400;
      public static int unauthorized = 401;
      public static int DeletedUserCode = 402;
        
    }
}
