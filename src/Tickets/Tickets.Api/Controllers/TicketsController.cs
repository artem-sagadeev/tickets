using Microsoft.AspNetCore.Mvc;
using Tickets.Api.Models.Requests;
using Tickets.Application.Dto;
using Tickets.Application.Interfaces;

namespace Tickets.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly ITicketService _ticketService;

    public TicketsController(ITicketService ticketService) => _ticketService = ticketService;

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateTicketTypeModel model)
    {
        var id = await _ticketService.CreateAsync(model.EventId, model.Title, model.Description, model.MaxCount,
            model.SalesStartDate, model.SalesEndDate);

        if (id is null)
            return BadRequest();

        return Ok(id);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(UpdateTicketTypeModel model)
    {
        await _ticketService.UpdateAsync(model.Id, model.Title, model.Description, model.MaxCount,
            model.SalesStartDate, model.SalesEndDate);

        return Ok();
    }

    [HttpGet("{ticketTypeId:guid}")]
    public async Task<TicketTypeDto> GetTicketType(Guid ticketTypeId) =>
        await _ticketService.GetByIdAsync(ticketTypeId);

    [HttpGet("byEvent/{eventId:guid}")]
    public async Task<IReadOnlyCollection<TicketTypeDto>> GetEventTicketTypes(Guid eventId) =>
        await _ticketService.GetByEventAsync(eventId);
}
