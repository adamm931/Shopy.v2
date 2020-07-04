using MediatR;
using Shopy.Application.Base;
using Shopy.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Categories.Edit
{
    public class EditCategorytCommandHandler : ShopyRequestHandler<EditCategoryCommand>
    {
        public EditCategorytCommandHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(EditCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = await Context.Categories.ByExternalIdAsync(command.ExternalId);

            category.Update(command.Name, command.Description);

            await Context.Save();

            return Unit.Value;
        }
    }
}