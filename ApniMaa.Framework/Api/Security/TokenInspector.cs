using ApniMaa.BLL.Common;
using ApniMaa.BLL.Interfaces;
using ApniMaa.BLL.Models;
using ApniMaa.Framework.Api;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace ApniMaa.Framework.Api.Security
{
    public class TokenInspector : DelegatingHandler
    {

        private readonly IUserManager _userManager;


        public TokenInspector(IUserManager userManager)
        {
            if (userManager == null)
                throw new ArgumentNullException("factory");
            _userManager = userManager;
        }


        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            const string TOKEN_NAME = "X-Token";

            if (request.Headers.Contains(TOKEN_NAME))
            {
                string Token = request.Headers.GetValues(TOKEN_NAME).First();
                try
                {
                    var found = _userManager.IsSessionValid(Token);
                    if (found == null)
                    {
                        HttpResponseMessage reply = new HttpResponseMessage()
                        {
                            StatusCode = HttpStatusCode.Unauthorized,
                            Content = new JsonContent(Messages.INVALID_SESSION, Status.Failed)
                        };
                        return Task.FromResult(reply);
                    }

                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(found.Email), null);
                }
                catch (Exception ex)
                {
                    HttpResponseMessage reply = new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.Unauthorized,
                        Content = new JsonContent(Messages.INVALID_TOKEN, Status.Failed)
                    };
                    return Task.FromResult(reply);
                }
            }
            else
            {
                HttpResponseMessage reply = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = new JsonContent(Messages.MISSING_TOKEN, Status.Failed)
                };
                return Task.FromResult(reply);
            }

            return base.SendAsync(request, cancellationToken);
        }

    }
}
