using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using OwinWebApiSelfHost.Infrastructure.ExceptionHandling;

[assembly: OwinStartup(typeof(OwinWebApiSelfHost.Startup))]

namespace OwinWebApiSelfHost
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            //app.UseWelcomePage("/");
            //app.UseErrorPage();

            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();

            //  Enable attribute based routing
            //  http://www.asp.net/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2
            config.MapHttpAttributeRoutes();

            // There can be multiple exception loggers. (By default, no exception loggers are registered.)
            config.Services.Add(typeof(IExceptionLogger), new SerilogExceptionLogger());

            // Replace the default exception handler
            config.Services.Replace(typeof(IExceptionHandler), new CustomExceptionHandler());

            app.UseWebApi(config);
        
        }
    }
}
