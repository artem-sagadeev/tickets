namespace Events.Api.Models
{
    public class CreateEventModel
    {
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public DateOnly Date { get; set; }
        
        public TimeOnly? StartTime { get; set; }
        
        public TimeOnly? EndTime { get; set; }
        
        public Guid OrganizationId { get; set; }
    }
}