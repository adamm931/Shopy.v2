using System.Threading.Tasks;

namespace Shopy.Application.Interfaces
{
    public interface IAuthService
    {
        string User { get; }

        Task<string> GenerateToken(string username);

        Task<bool> CheckUsername(string username);

        Task<bool> Authenticate(string username, string password);
    }
}