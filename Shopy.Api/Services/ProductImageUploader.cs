using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shopy.Application.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

public class ProductImageUploader : IProductImageUploader
{
    private readonly IHostEnvironment _hostEnvironment;

    private readonly ILogger<ProductImageUploader> _logger;

    public ProductImageUploader(IHostEnvironment hostEnvironment, ILogger<ProductImageUploader> logger)
    {
        _hostEnvironment = hostEnvironment;
        _logger = logger;
    }

    public async Task UploadAsync(string imageName, string base64String, Guid productExternalId)
    {
        var currentPath = _hostEnvironment.ContentRootPath;

        var imagePath = @$"{currentPath}\..\Shopy.Api\Images\{productExternalId}\{imageName}.png";

        _logger.LogInformation($"Saving image: {imageName} for product: {productExternalId}");

        var image = Convert.FromBase64String(base64String);

        await File.WriteAllBytesAsync(imagePath, image);

        _logger.LogInformation($"Saved image: {imageName} for product: {productExternalId}");
    }
}
