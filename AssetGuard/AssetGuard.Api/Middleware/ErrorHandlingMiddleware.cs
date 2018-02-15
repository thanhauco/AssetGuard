using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using AssetGuard.Core.Exceptions;

namespace AssetGuard.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;

            switch (exception)
            {
                case NotFoundException e:
                    code = HttpStatusCode.NotFound;
                    result = JsonConvert.SerializeObject(new { error = e.Message });
                    break;
                case BadRequestException e:
                    code = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(new { error = e.Message });
                    break;
                default:
                    code = HttpStatusCode.InternalServerError;
                    result = JsonConvert.SerializeObject(new { error = "An unexpected error occurred." });
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }
}
