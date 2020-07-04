using Shopy.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.Client.Interfaces
{
    public interface IBrandsApi
    {
        Task<IEnumerable<BrandResponse>> ListAsync();
    }
}
