using Events.Application.Dto;

namespace Events.Application.Interfaces
{
    public interface IEventService
    {
        Task<EventDto> GetById(Guid eventId);

        Task<Guid> Create(string title);
    }
}