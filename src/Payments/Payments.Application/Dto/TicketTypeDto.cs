﻿namespace Payments.Application.Dto;

public record TicketTypeDto
{
    public Guid Id { get; set; }

    public Guid EventId { get; set; }

    public required string Title { get; set; }

    public string? Description { get; set; }

    public int MaxCount { get; set; }

    public DateTime SalesStartDate { get; set; }

    public DateTime SalesEndDate { get; set; }
}
