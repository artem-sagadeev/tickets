﻿using Payments.Application.Dto;

namespace Payments.Application.Interfaces;

public interface IPaymentService
{
    ValueTask<PaymentDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    ValueTask<IReadOnlyCollection<PaymentDto>> GetByTicketTypeAsync(Guid ticketTypeId,
        CancellationToken cancellationToken = default);

    ValueTask<IReadOnlyCollection<PaymentDto>> GetByUserAsync(Guid userId,
        CancellationToken cancellationToken = default);

    ValueTask BuyAsync(Guid ticketTypeId, Guid userId, int count, CancellationToken cancellationToken = default);
}
