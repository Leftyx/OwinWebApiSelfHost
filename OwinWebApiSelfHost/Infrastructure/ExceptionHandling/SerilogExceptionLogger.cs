namespace OwinWebApiSelfHost.Infrastructure.ExceptionHandling
{
    using System;
    using System.Web;
    using System.Net.Http;
    using System.Web.Http.ExceptionHandling;
    using System.Threading.Tasks;
    using Microsoft.Owin;
    using Serilog;
    using System.Collections.Generic;
using System.Collections.Specialized;
    using System.IO;

    public class SerilogExceptionLogger : ExceptionLogger
    {
        public SerilogExceptionLogger()
        {
            Serilog.Log.Logger = new LoggerConfiguration()
                .ReadAppSettings()
                .Enrich.WithMachineName()
                .CreateLogger();
        }

        public override void Log(ExceptionLoggerContext context)
        {
            TraceException(context);
        }

        public override async System.Threading.Tasks.Task LogAsync(ExceptionLoggerContext context, System.Threading.CancellationToken cancellationToken)
        {
            TraceException(context);
        }

        private void TraceException(ExceptionLoggerContext context)
        {
            var request = new SerilogRequestMessage(context.Request);
            var exceptionContext = new SerilogExceptionContext(context.ExceptionContext);

            Serilog.Log.Error("{@Request}", request);
            Serilog.Log.Error("{@ExceptionContext}", exceptionContext);
            Serilog.Log.Error(context.Exception, "{StackTrace}", "=>");
        }
    }
}