using Shopy.Application.Base;
using Shopy.Application.Interfaces;
using Shopy.Domain.Entitties;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Categories.Add
{
    public class AddCategoryHandler : ShopyRequestHandler<AddCategoryCommand, Guid>
    {
        public AddCategoryHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<Guid> Handle(AddCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = new Category(command.Name, command.Description);

            Context.Categories.Add(category);

            await Context.Save();

            return category.ExternalId;
        }
    }
}