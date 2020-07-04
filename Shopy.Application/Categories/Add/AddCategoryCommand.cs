using MediatR;
using System;

namespace Shopy.Application.Categories.Add
{
    public class AddCategoryCommand : IRequest<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}