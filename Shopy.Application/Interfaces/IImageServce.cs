using System;
using System.Threading.Tasks;

namespace Shopy.Application.Interfaces
{
    public interface IImageService
    {
        Task UploadAsync(string imageName, string base64Content, Guid externalId);
    }
}
