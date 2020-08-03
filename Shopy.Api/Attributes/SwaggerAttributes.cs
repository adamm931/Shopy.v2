using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace Shopy.Api.Attributes
{
    public class SwaggerResponseAttribute : ProducesResponseTypeAttribute
    {
        public SwaggerResponseAttribute(Type type, HttpStatusCode statusCode = HttpStatusCode.OK)
            : base(type, (int)statusCode)
        {
        }

        public SwaggerResponseAttribute(HttpStatusCode statusCode = HttpStatusCode.OK)
            : base((int)statusCode)
        {
        }
    }
}
