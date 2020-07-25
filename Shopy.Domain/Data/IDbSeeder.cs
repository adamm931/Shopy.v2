using System.Threading.Tasks;

namespace Shopy.Domain.Data
{
    public interface IDbSeeder
    {
        Task Seed();
    }
}
