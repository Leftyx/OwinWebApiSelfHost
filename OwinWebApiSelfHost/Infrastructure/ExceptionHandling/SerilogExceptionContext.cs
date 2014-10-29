using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinWebApiSelfHost.Infrastructure.ExceptionHandling
{
    public class SerilogExceptionContext
    {
        public Dictionary<string, object>.ValueCollection ActionArguments { get; set; }

        public SerilogExceptionContext(System.Web.Http.ExceptionHandling.ExceptionContext exceptionContext)
        {
            try
            {
                this.ActionArguments = ((System.Web.Http.ApiController)exceptionContext.ControllerContext.Controller).ActionContext.ActionArguments.Values;
            }
            catch (Exception)
            {
            }
        }
    }
}
