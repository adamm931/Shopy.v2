using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Shopy.Domain.Exceptions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Shopy.Api.Middleware
{
    public class ShopyExceptionMiddleware
    {
        private readonly RequestDelegate next;
        public ShopyExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            // TODO: Authorize api
            var code = HttpStatusCode.InternalServerError;

            if (ex is ValidationException) code = HttpStatusCode.BadRequest;
            if (ex is EntityNotFoundException) code = HttpStatusCode.NotFound;

            var result = JsonConvert.SerializeObject(new { error = ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
