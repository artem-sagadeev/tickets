using Common.Application.Exceptions;
using Events.Application.Dto;
using Events.Application.Interfaces;
using Events.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Events.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IApplicationContext _context;

        public EventService(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<EventDto> GetById(Guid eventId)
        {
            var @event = await _context.Events.FirstOrDefaultAsync(@event => @event.Id == eventId)
                ?? throw new EntityNotFoundException();

            return new EventDto
            {
                Id = @event.Id,
                Title = @event.Title
            };
        }

        public async Task<Guid> Create(string title)
        {
            var @event = new Event(title);

            _context.Events.Add(@event);
            await _context.SaveChangesAsync();

            return @event.Id;
        }
    }
}