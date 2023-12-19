using Microsoft.EntityFrameworkCore;
using Organizations.Application;
using Organizations.Domain.Entities;

namespace Organizations.Infrastructure;

public class ApplicationContext : DbContext, IApplicationContext
{
    public DbSet<Organization> Organizations { get; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
}