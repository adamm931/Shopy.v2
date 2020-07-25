using Shopy.Application.Interfaces;
using System;

namespace Shopy.Application.Categories.Edit
{
    public class EditCategoryCommand : ICommand
    {
        public Guid ExternalId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}