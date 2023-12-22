namespace Tickets.Domain.Entities;

public record TicketType
{
    public required Guid Id { get; set; }

    public required Guid EventId { get; set; }

    public required string Title { get; set; }

    public string? Description { get; set; }

    public int CurrentCount { get; set; }

    public int MaxCount { get; set; }

    public DateTime SalesStartDate { get; set; }

    public DateTime SalesEndDate { get; set; }
}
