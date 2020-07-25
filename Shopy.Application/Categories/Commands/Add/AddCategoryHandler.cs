using MediatR;
using Shopy.Domain.Data;
using Shopy.Domain.Entitties;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Categories.Commands.Add
{
    public class AddCategoryHandler : IRequestHandler<AddCategoryCommand, Guid>
    {
        private readonly IRepository<Category> categories;

        public AddCategoryHandler(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        public async Task<Guid> Handle(AddCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = await categories.Add(new Category(command.Name, command.Description));

            return category.ExternalId;
        }
    }
}