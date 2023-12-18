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
            var _event = await GetEventById(eventId);

            return new EventDto(_event);
        }

        public async Task<IEnumerable<EventDto>> GetByOrganizationId(Guid organizationId)
        {
            var events = await _context.Events
                .Where(_event => _event.OrganizationId == organizationId && !_event.IsDeleted)
                .Select(_event => new EventDto(_event))
                .ToListAsync();

            return events;
        }
        
        public async Task<IEnumerable<EventDto>> SearchEvents(
            string? searchString, 
            DateOnly? from,
            DateOnly? to)
        {
            var events = await _context.Events.Where(_event =>
                !_event.IsDeleted &&
                (searchString == null || _event.Title.ToLower().Contains(searchString.ToLower())) &&
                (from == null || _event.Date >= from) &&
                (to == null || _event.Date <= to))
                .Select(_event => new EventDto(_event))
                .ToListAsync();

            return events;
        }

        public async Task<Guid> Create(
            string title,
            string description,
            DateOnly date,
            Guid organizationId,
            TimeOnly? startTime,
            TimeOnly? endTime)
        {
            var _event = new Event(title, description, date, organizationId, startTime, endTime);

            _context.Events.Add(_event);
            await _context.SaveChangesAsync();

            return _event.Id;
        }

        public async Task Update(
            Guid eventId,
            string title,
            string description,
            DateOnly date,
            TimeOnly? startTime,
            TimeOnly? endTime)
        {
            var _event = await GetEventById(eventId);
            
            _event.Update(title, description, date, startTime, endTime);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid eventId)
        {
            var _event = await GetEventById(eventId);
            
            _event.Delete();

            await _context.SaveChangesAsync();
        }

        private async Task<Event> GetEventById(Guid eventId)
        {
            return await _context.Events
                       .Where(_event => !_event.IsDeleted)
                       .FirstOrDefaultAsync(_event => _event.Id == eventId)
                   ?? throw new EntityNotFoundException("Мероприятие не найдено");
        }
    }
}