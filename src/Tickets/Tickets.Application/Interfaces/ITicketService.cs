using Tickets.Application.Dto;

namespace Tickets.Application.Interfaces;

public interface ITicketService
{
    ValueTask<TicketTypeDto> GetTicketTypeAsync(Guid id, CancellationToken cancellationToken = default);

    ValueTask<TicketDto> GetTicketAsync(Guid id, CancellationToken cancellationToken = default);
}