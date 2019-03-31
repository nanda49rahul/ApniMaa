using ApniMaa.BLL.Models;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApniMaa.BLL.Helpers
{
    public static class AuthenticateToken
    {
        public static string GenerateToken(string parameter)
        {
            IDateTimeProvider provider = new UtcDateTimeProvider();
            var now = provider.GetNow();
            var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var secondsSinceEpoch = Math.Round((now - unixEpoch).TotalSeconds);
            secondsSinceEpoch += 3600;
            var payload = new Dictionary<string, object>
                {
                    { "UserEmail", parameter },
                    { "exp", secondsSinceEpoch }
                };
            var secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            var token = encoder.Encode(payload, secret);
            return token;
        }

        public static ActionOutput ValidateToken(string token)
        {
            var secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);
                var json = decoder.Decode(token, secret, verify: true);
                return new ActionOutput { Message = json, Status = ActionStatus.Successfull };
            }
            catch (TokenExpiredException ex)
            {
                return new ActionOutput { Message = "Token has been expired", Status = ActionStatus.Error };
            }
            catch (SignatureVerificationException)
            {
                return new ActionOutput { Message = "Token has invalid signature", Status = ActionStatus.Error };
            }
        }


    }
}
