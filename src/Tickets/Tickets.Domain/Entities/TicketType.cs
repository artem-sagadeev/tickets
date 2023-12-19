namespace Tickets.Domain.Entities;

public class TicketType
{
    public Guid Id { get; set; }

    public Guid EventId { get; set; }

    public string? Description { get; set; }

    public int MaxCount { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}