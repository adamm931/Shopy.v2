using MediatR;
using Shopy.Application.Models;
using System.Collections.Generic;

namespace Shopy.Application.Categories.Commands.Add
{
    public class LookupCategoriesQuery : IRequest<IEnumerable<LookupResponse>>
    {
    }
}