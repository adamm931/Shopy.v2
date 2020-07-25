using MediatR;
using Shopy.Application.Interfaces;
using Shopy.Domain.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Pipelines
{
    public class UnitOfWorkPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IUnitOfWork unitOfWork;

        public UnitOfWorkPipeline(IUnitOfWork logger)
        {
            unitOfWork = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var response = await next();

            if (request is ICommand || request is ICommand<TResponse>)
            {
                await unitOfWork.Save();
            }

            return response;
        }
    }
}
