using Shopy.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.Client.Interfaces
{
    public interface ISizesApi
    {
        Task<IEnumerable<SizeResponse>> ListAsync();
    }
}
