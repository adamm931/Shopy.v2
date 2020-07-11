using Microsoft.EntityFrameworkCore;
using Shopy.Domain.Entitties;
using System;
using System.Threading.Tasks;

namespace Shopy.Application.Interfaces
{
    public interface IShopyContext : IDisposable
    {
        DbSet<Product> Products { get; }

        DbSet<Category> Categories { get; }

        Task Save();

        Task<bool> IsCreated();
    }
}
