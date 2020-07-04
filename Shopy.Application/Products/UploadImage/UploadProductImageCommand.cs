using MediatR;
using System;

namespace Shopy.Application.Products.UploadImage
{
    public class UploadProductImageCommand : IRequest
    {
        public Guid ExternalId { get; set; }

        public string ImageName { get; set; }

        public string Base64String { get; set; }
    }
}
