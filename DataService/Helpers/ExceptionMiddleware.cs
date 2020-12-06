using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PointOfSale.DataService.Helpers
{
    public class ErrorMessage
    {
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public string Stacktrace { get; set; }
    }
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            ExceptionLog.Log(exception);

            var result = new ErrorMessage()
            {
                StatusCode = HttpStatusCode.InternalServerError.ToString(),
                Message = exception.Message ?? exception.InnerException.ToString(),
                Stacktrace = exception.StackTrace
            };

            var jsonResult = JsonConvert.SerializeObject(result);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(jsonResult);

        }
    }
}
