namespace Tickets.Domain.Entities;

public class Ticket
{
    public Guid Id { get; set; }

    public Guid TicketTypeId { get; set; }

    public Guid? UserId { get; set; }

    public TicketStatus Status { get; set; }
}