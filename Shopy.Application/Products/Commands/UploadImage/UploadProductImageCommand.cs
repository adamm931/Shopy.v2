using Shopy.Application.Interfaces;
using System;

namespace Shopy.Application.Products.UploadImage
{
    public class UploadProductImageCommand : ICommand
    {
        public Guid ExternalId { get; set; }

        public string ImageName { get; set; }

        public string Base64String { get; set; }
    }
}
