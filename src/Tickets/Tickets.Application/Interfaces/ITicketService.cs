using Tickets.Application.Dto;

namespace Tickets.Application.Interfaces;

public interface ITicketService
{
    ValueTask<Guid?> CreateAsync(Guid event_id, string title, string? description, int maxCount, DateTime salesStartDate,
        DateTime salesEndDate, CancellationToken cancellationToken = default);

    ValueTask UpdateAsync(Guid id, string title, string? description, int maxCount, DateTime salesStartDate,
        DateTime salesEndDate, CancellationToken cancellationToken = default);

    ValueTask<TicketTypeDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    ValueTask<IReadOnlyCollection<TicketTypeDto>> GetByEventAsync(Guid event_id,
        CancellationToken cancellationToken = default);
}
