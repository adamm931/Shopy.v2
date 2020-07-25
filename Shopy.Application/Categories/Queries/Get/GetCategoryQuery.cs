using MediatR;
using Shopy.Application.Models;
using System;

namespace Shopy.Application.Categories.Queries.Get
{
    public class GetCategoryQuery : IRequest<CategoryReponse>
    {
        public Guid ExternalId { get; set; }

        public GetCategoryQuery(Guid externalId)
        {
            ExternalId = externalId;
        }
    }
}