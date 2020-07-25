using Shopy.Application.Interfaces;
using System;

namespace Shopy.Application.Categories.Delete
{
    public class DeleteCategoryCommand : ICommand
    {
        public Guid ExternalId { get; set; }
    }
}
