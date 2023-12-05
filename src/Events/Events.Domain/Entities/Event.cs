namespace Events.Domain.Entities
{
    public class Event
    {
        public Guid Id { get; private set; }
        
        public string Title { get; private set; }

        public Event(string title)
        {
            Title = title;
        }
        
        private Event() {}
    }
}