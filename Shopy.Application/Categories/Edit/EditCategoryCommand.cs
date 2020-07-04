using MediatR;
using System;

namespace Shopy.Application.Categories.Edit
{
    public class EditCategoryCommand : IRequest<Unit>
    {
        public Guid ExternalId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}