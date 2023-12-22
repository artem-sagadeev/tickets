using Payments.Application.Dto;
using Payments.Application.Ports;

namespace Payments.Infrastructure.Clients;

public class TicketGrpcClient : ITicketGrpcClient
{
    public ValueTask<TicketTypeDto> GetTicketTypeAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}