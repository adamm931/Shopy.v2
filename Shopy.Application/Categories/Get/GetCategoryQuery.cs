using MediatR;
using Shopy.Application.Models;
using System;

namespace Shopy.Application.Categories.Add
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