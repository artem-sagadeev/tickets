using Microsoft.EntityFrameworkCore;
using Tickets.Domain.Entities;

namespace Tickets.Application;

public interface IApplicationContext
{
    DbSet<TicketType> TicketTypes { get; }
    
    DbSet<Ticket> Tickets { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
