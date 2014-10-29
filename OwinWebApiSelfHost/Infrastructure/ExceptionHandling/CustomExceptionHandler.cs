namespace OwinWebApiSelfHost.Infrastructure.ExceptionHandling
{
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http.ExceptionHandling;

    public class CustomExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            context.Result = new InternalServerErrorResult("An unhandled exception occurred; check the log for more information.", Encoding.UTF8, context.Request);
        }

        public async override System.Threading.Tasks.Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            context.Result = new InternalServerErrorResult("An unhandled exception occurred; check the log for more information.", Encoding.UTF8, context.Request);
        }
    }
}