using System.Threading.Tasks;

namespace Shopy.Domain.Data
{
    public interface IUnitOfWork
    {
        Task Save();
    }
}
