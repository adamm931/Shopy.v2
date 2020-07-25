using MediatR;
using Shopy.Domain.Data;
using Shopy.Domain.Entitties;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Categories.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IRepository<Category> categories;

        public DeleteCategoryCommandHandler(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            await categories.Remove(request.ExternalId);

            return Unit.Value;
        }
    }
}
