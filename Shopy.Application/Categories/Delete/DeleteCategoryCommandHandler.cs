using MediatR;
using Shopy.Application.Base;
using Shopy.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Categories.Delete
{
    public class DeleteCategoryCommandHandler : ShopyRequestHandler<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandHandler(IShopyContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await Context.Categories.ByExternalIdAsync(request.ExternalId);
            Context.Categories.Remove(category);

            await Context.Save();

            return Unit.Value;
        }
    }
}
