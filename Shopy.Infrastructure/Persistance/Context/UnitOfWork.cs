using Shopy.Common.Extensions;
using Shopy.Domain.Data;
using Shopy.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.Infrastructure.Persistance.Context
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly IEnumerable<IOnSaveHandler> onSaveHandlers;

        private readonly ShopyDbContext context;

        public UnitOfWork(
            IEnumerable<IOnSaveHandler> onSaveHandlers,
            ShopyDbContext context)
        {
            this.onSaveHandlers = onSaveHandlers;
            this.context = context;
        }

        public async Task Save()
        {
            onSaveHandlers.Each(handler => handler.OnSave(context));

            await context.SaveChangesAsync();
        }
    }
}
