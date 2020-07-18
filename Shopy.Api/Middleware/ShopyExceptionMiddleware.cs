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
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = MapExceptionToStatusCode(ex);

            var result = JsonConvert.SerializeObject(new
            {
                Error = ex.Message
            });

            return context.Response.WriteAsync(result);
        }

        private static int MapExceptionToStatusCode(Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            if (exception is ValidationException)
            {
                code = HttpStatusCode.BadRequest;
            }

            if (exception is EntityNotFoundException)
            {
                code = HttpStatusCode.NotFound;
            }

            return (int)code;
        }
    }
}
