using Shopy.Application.Interfaces;
using System;

namespace Shopy.Application.Categories.Commands.Add
{
    public class AddCategoryCommand : ICommand<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}