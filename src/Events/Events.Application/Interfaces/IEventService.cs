using Events.Application.Dto;

namespace Events.Application.Interfaces
{
    public interface IEventService
    {
        Task<EventDto> GetById(Guid eventId);

        Task<IEnumerable<EventDto>> GetByOrganizationId(Guid organizationId);
        
        Task<IEnumerable<EventDto>> SearchEvents(string? searchString);

        Task<Guid> Create(string title, string description, DateOnly date, Guid organizationId, 
            TimeOnly? startTime, TimeOnly? endTime, string? imageName);

        Task Update(Guid eventId, string title, string description, DateOnly date, TimeOnly? startTime, 
            TimeOnly? endTime);

        Task Delete(Guid eventId);
    }
}