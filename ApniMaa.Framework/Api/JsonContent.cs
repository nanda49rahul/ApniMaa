using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ApniMaa.Framework.Api
{
    public class JsonContent : HttpContent
    {
        private readonly JToken _value;

        public JsonContent(string message, int status, object data = null, string token = null, char? verified = null)
        {
            Response st = new Response { Message = message, Status = status, result = data, token = token, verified = verified };

            _value = JObject.Parse(JsonConvert.SerializeObject(st));
            Headers.ContentType = new MediaTypeHeaderValue("application/json");
        }

        protected override Task SerializeToStreamAsync(Stream stream,
            TransportContext context)
        {
            var jw = new JsonTextWriter(new StreamWriter(stream))
            {
                Formatting = Formatting.Indented
            };
            _value.WriteTo(jw);
            jw.Flush();
            return Task.FromResult<object>(null);
        }

        protected override bool TryComputeLength(out long length)
        {
            length = -1;
            return false;
        }
    }
}
