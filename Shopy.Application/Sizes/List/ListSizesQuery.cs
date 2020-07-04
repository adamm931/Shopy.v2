using MediatR;
using Shopy.Application.Models;
using System.Collections.Generic;

namespace Shopy.Application.Sizes.List
{
    public class ListSizesQuery : IRequest<IEnumerable<SizeResponse>>
    {
    }
}