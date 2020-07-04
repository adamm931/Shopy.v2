using MediatR;
using System;

namespace Shopy.Application.Categories.Delete
{
    public class DeleteCategoryCommand : IRequest<Unit>
    {
        public Guid ExternalId { get; set; }

        public DeleteCategoryCommand(Guid externalId)
        {
            ExternalId = externalId;
        }
    }
}
