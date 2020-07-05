using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shopy.Application.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Shopy.Infrastructure.Images
{
    public class ImageUploader : IImageUploader
    {
        private readonly IHostEnvironment _hostEnvironment;

        private readonly ILogger<ImageUploader> _logger;

        public ImageUploader(IHostEnvironment hostEnvironment, ILogger<ImageUploader> logger)
        {
            _hostEnvironment = hostEnvironment;
            _logger = logger;
        }

        public async Task UploadAsync(string imageName, string base64String, Guid externalId)
        {
            var currentPath = _hostEnvironment.ContentRootPath;

            var imagePath = @$"{currentPath}\..\Shopy.Api\Images\{externalId}\{imageName}.png";

            _logger.LogInformation($"Saving image: {imageName} for product: {externalId}");

            var image = Convert.FromBase64String(base64String);

            await File.WriteAllBytesAsync(imagePath, image);

            _logger.LogInformation($"Saved image: {imageName} for product: {externalId}");
        }
    }
}

