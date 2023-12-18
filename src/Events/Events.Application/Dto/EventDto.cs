using Events.Domain.Entities;

namespace Events.Application.Dto
{
    public class EventDto
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public DateOnly Date { get; set; }
        
        public TimeOnly? StartTime { get; set; }
        
        public TimeOnly? EndTime { get; set; }
        
        public Guid OrganizationId { get; set; }
        
        public bool IsPast { get; set; }

        public EventDto(Event _event)
        {
            Id = _event.Id;
            Title = _event.Title;
            Description = _event.Description;
            Date = _event.Date;
            StartTime = _event.StartTime;
            EndTime = _event.EndTime;
            OrganizationId = _event.OrganizationId;
            IsPast = _event.IsPast;
        }
    }
}