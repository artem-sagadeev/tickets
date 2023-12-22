﻿namespace Tickets.Domain.Entities;

public record TicketType
{
    public required Guid Id { get; init; }

    public required Guid EventId { get; init; }

    public required string Title { get; init; }

    public string? Description { get; init; }

    public int MaxCount { get; init; }

    public DateTime SalesStartDate { get; init; }

    public DateTime SalesEndDate { get; init; }
}
