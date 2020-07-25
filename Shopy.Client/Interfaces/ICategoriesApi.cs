using Shopy.Application.Categories.Commands.Add;
using Shopy.Application.Categories.Edit;
using Shopy.Application.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.Client.Interfaces
{
    public interface ICategoriesApi
    {
        Task<IEnumerable<LookupResponse>> LookupAsync();

        Task<CategoryReponse> GetAsync(Guid ExternalId);

        Task<Guid> AddAsync(AddCategoryCommand category);

        Task EditAsync(EditCategoryCommand category);

        Task DeleteAsync(Guid ExternalId);
    }
}
