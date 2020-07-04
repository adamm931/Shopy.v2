using System.Threading.Tasks;

namespace Shopy.Application.Interfaces
{
    public interface ITokenProvider
    {
        public Task<string> GenerateToken(string user, string password);
    }
}