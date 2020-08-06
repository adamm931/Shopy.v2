using System.Threading.Tasks;

namespace Shopy.Application.Interfaces
{
    public interface IAuthProvider
    {
        string User { get; }

        Task<string> GenerateToken(string user);

        Task<bool> Authenticate(string user, string password);
    }
}