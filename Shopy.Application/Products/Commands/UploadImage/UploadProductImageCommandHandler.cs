using MediatR;
using Shopy.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Products.UploadImage
{
    public class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommand>
    {
        private readonly IImageService _uploader;

        public UploadProductImageCommandHandler(IImageService uploader)
        {
            _uploader = uploader;
        }

        public async Task<Unit> Handle(UploadProductImageCommand command, CancellationToken cancellationToken)
        {
            await _uploader.UploadAsync(command.ImageName, command.Base64String, command.ExternalId);

            return Unit.Value;
        }
    }
}
