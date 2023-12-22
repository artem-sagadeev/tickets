using Common.Application.Exceptions;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Tickets.Application.Dto;
using Tickets.Application.Interfaces;
using Tickets.Domain.Entities;

namespace Tickets.Application.Services;

public class TicketService : ITicketService
{
    private readonly IApplicationContext _context;

    public TicketService(IApplicationContext context) => _context = context;

    public async ValueTask<Guid?> CreateAsync(Guid event_id, string title, string? description, int maxCount,
        DateTime salesStartDate, DateTime salesEndDate, CancellationToken cancellationToken = default)
    {
        if (!await IsUniqueName(event_id, title, cancellationToken))
            return null;

        var ticketTypeId = Guid.NewGuid();
        var ticketType = new TicketType
        {
            Id = Guid.NewGuid(),
            EventId = event_id,
            Title = title,
            Description = description,
            MaxCount = maxCount,
            SalesStartDate = salesStartDate,
            SalesEndDate = salesEndDate
        };

        await _context.TicketTypes.AddAsync(ticketType, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return ticketTypeId;
    }

    public async ValueTask UpdateAsync(Guid event_id, string title, string? description, int maxCount,
        DateTime salesStartDate, DateTime salesEndDate, CancellationToken cancellationToken = default)
    {

    }

    public async ValueTask<TicketTypeDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.TicketTypes.SingleOrDefaultAsync(item => item.Id == id,
                         cancellationToken: cancellationToken) ??
                     throw new EntityNotFoundException("Тип билета не найден.");
        var dto = entity.Adapt<TicketTypeDto>();

        return dto;
    }

    public async ValueTask<IReadOnlyCollection<TicketTypeDto>> GetByEventAsync(Guid event_id,
        CancellationToken cancellationToken = default) => (await _context.TicketTypes
            .Where(entity => entity.EventId == event_id)
            .ToArrayAsync(cancellationToken: cancellationToken))
        .Select(entity => entity.Adapt<TicketTypeDto>())
        .ToArray();

    private async ValueTask<bool> IsUniqueName(Guid event_id, string title,
        CancellationToken cancellationToken = default) => await _context.TicketTypes
        .AnyAsync(entity => entity.EventId == event_id && entity.Title == title, cancellationToken: cancellationToken);
}
