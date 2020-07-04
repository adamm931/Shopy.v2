using MediatR;
using Shopy.Application.Models;
using System.Collections.Generic;

namespace Shopy.Application.Brands.List
{
    public class ListBrandsQuery : IRequest<IEnumerable<BrandResponse>>
    {
    }
}