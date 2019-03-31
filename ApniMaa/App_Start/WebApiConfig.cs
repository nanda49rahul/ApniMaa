using ApniMaa.App_Start;
//using ApniMaa.Framework.Api.Security;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using Newtonsoft.Json;
//using System.Web.UI.WebControls;

namespace ApniMaa.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            //TokenInspector tokenInspector = (TokenInspector)NinjectWebCommon.Kernel.GetService(typeof(TokenInspector));
            //tokenInspector.InnerHandler = new HttpControllerDispatcher(config);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "AnotherDefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: null
            );
        }
    }
}
