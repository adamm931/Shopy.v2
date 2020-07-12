using Microsoft.EntityFrameworkCore;

namespace Shopy.Infrastructure.Interfaces
{
    public interface IOnSave
    {
        void OnSave(DbContext context);
    }
}
