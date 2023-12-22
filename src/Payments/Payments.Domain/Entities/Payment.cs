namespace Payments.Domain.Entities;

public record Payment
{
    public Guid Id { get; set; }

    public Guid TicketTypeId { get; set; }

    public Guid UserId { get; set; }

    public PurchaseStatus PurchaseStatus { get; set; }

    public DateTime ChangeDate { get; set; }
}
