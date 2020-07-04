using System;
using System.Threading.Tasks;

namespace Shopy.Application.Interfaces
{
    public interface IProductImageUploader
    {
        Task UploadAsync(string imageName, string base64Content, Guid productExternalId);
    }
}
