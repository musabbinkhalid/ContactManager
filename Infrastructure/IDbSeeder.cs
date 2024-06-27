using ContactManager.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Infrastructure
{
    public interface IDbSeeder
    {
        Task SeedAsync();
    }
}
