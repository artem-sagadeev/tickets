using Organizations.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Organizations.Application;

public interface IApplicationContext
{
    DbSet<Organization> Organizations { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}