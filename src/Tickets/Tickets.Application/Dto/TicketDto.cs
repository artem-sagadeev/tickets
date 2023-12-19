using Tickets.Domain.Entities;

namespace Tickets.Application.Dto;

public record TicketDto
{
    public Guid Id { get; set; }

    public Guid TicketTypeId { get; set; }

    public Guid? UserId { get; set; }

    public TicketStatus Status { get; set; }
}