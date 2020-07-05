using System.Threading.Tasks;

namespace Shopy.Application.Interfaces
{
    public interface IAuthProvider
    {
        string User { get; }

        public Task<string> GenerateToken(string user);
    }
}