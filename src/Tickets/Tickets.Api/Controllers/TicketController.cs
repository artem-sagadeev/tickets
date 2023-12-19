using Microsoft.AspNetCore.Mvc;
using Tickets.Application.Dto;
using Tickets.Application.Interfaces;

namespace Tickets.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketController : ControllerBase
{
    private readonly ITicketService _ticketService;

    public TicketController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpGet("{ticketTypeId:guid}")]
    public async Task<TicketTypeDto> GetTicketType(Guid ticketTypeId) =>
        await _ticketService.GetTicketTypeAsync(ticketTypeId);
    
    [HttpGet("{ticketId:guid}")]
    public async Task<TicketDto> GetTicket(Guid ticketId) => await _ticketService.GetTicketAsync(ticketId);
}