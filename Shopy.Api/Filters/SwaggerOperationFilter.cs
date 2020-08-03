using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Shopy.Api.Common;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Shopy.Api.Filters
{
    public class SwaggerOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var shouldAuthorize = context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any() ||
                              context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();

            if (!shouldAuthorize)
            {
                return;
            }

            AddHttpStatusCode(operation, HttpStatusCode.BadRequest);
            AddHttpStatusCode(operation, HttpStatusCode.NotFound);
            AddHttpStatusCode(operation, HttpStatusCode.Unauthorized);

            AddJwtBearer(operation);
        }

        private void AddJwtBearer(OpenApiOperation operation)
        {
            var jwtbearerScheme = new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = ApiConstants.Bearer }
            };

            operation.Security = new List<OpenApiSecurityRequirement>
            {
                new OpenApiSecurityRequirement
                {
                    [ jwtbearerScheme ] = new string [] { }
                }
            };
        }

        private void AddHttpStatusCode(OpenApiOperation operation, HttpStatusCode statusCode)
        {
            var code = ((int)statusCode).ToString();

            operation.Responses.TryAdd(code, new OpenApiResponse { Description = statusCode.ToString() });
        }
    }
}
