using Microsoft.EntityFrameworkCore;

namespace Shopy.Infrastructure.Interfaces
{
    public interface IOnSaveHandler
    {
        void OnSave(DbContext context);
    }
}
