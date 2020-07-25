using System.Threading.Tasks;

namespace Shopy.Domain.Data
{
    public interface IDbInitializer
    {
        Task<bool> Init();
    }
}
