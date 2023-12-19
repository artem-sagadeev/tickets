using Common.Application.Exceptions;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Tickets.Application.Dto;
using Tickets.Application.Interfaces;

namespace Tickets.Application.Services;

public class TicketService : ITicketService
{
    private readonly IApplicationContext _context;

    public TicketService(IApplicationContext context)
    {
        _context = context;
    }

    public async ValueTask<TicketTypeDto> GetTicketTypeAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.TicketTypes.SingleOrDefaultAsync(cancellationToken: cancellationToken) ??
                         throw new EntityNotFoundException();
        var dto = entity.Adapt<TicketTypeDto>();

        return dto;
    }

    public async ValueTask<TicketDto> GetTicketAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Tickets.SingleOrDefaultAsync(cancellationToken: cancellationToken) ??
                     throw new EntityNotFoundException();
        var dto = entity.Adapt<TicketDto>();

        return dto;
    }
}