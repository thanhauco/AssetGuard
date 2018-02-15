using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using AssetGuard.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace AssetGuard.Api.Filters
{
    public class AuditFilterAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Execute action
            var resultContext = await next();

            // After execution
            if (resultContext.Exception == null)
            {
                var auditService = context.HttpContext.RequestServices.GetService<IAuditService>();
                
                var action = context.ActionDescriptor.DisplayName;
                var controller = context.RouteData.Values["controller"].ToString();
                var args = JsonConvert.SerializeObject(context.ActionArguments);
                var user = context.HttpContext.User.Identity.IsAuthenticated ? context.HttpContext.User.Identity.Name : "Anonymous";
                var ip = context.HttpContext.Connection.RemoteIpAddress?.ToString();

                await auditService.LogAsync(action, controller, args, user, ip);
            }
        }
    }
}
