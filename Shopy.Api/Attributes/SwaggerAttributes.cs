using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace Shopy.Api.Attributes
{
    public class OkAttribute : ProducesResponseTypeAttribute
    {
        public OkAttribute(Type type) : base(type, (int)HttpStatusCode.OK)
        {
        }

        public OkAttribute() : base((int)HttpStatusCode.OK)
        {
        }
    }

    public class NotFoundAttribute : ProducesResponseTypeAttribute
    {
        public NotFoundAttribute() : base((int)HttpStatusCode.NotFound)
        {
        }
    }

    public class BadRequestAttribute : ProducesResponseTypeAttribute
    {
        public BadRequestAttribute() : base((int)HttpStatusCode.BadRequest)
        {
        }
    }

    public class UnauthorizedAttribute : ProducesResponseTypeAttribute
    {
        public UnauthorizedAttribute() : base((int)HttpStatusCode.Unauthorized)
        {
        }
    }
}
