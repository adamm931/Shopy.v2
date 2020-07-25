using MediatR;
using Shopy.Domain.Data;
using Shopy.Domain.Entitties;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Categories.Edit
{
    public class EditCategorytCommandHandler : IRequestHandler<EditCategoryCommand>
    {
        private readonly IRepository<Category> categories;

        public EditCategorytCommandHandler(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        public async Task<Unit> Handle(EditCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = await categories.Get(command.ExternalId);

            category.Update(command.Name, command.Description);

            return Unit.Value;
        }
    }
}