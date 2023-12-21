using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Clients;
using Web.Dto;

namespace Web.Pages.Events
{
    public class Event : PageModel
    {
        private readonly EventsClient _eventsClient;

        public Event(EventsClient eventsClient)
        {
            _eventsClient = eventsClient;
        }

        public EventDto? EventDto;
        
        public async Task OnGet(Guid id)
        {
            EventDto = await _eventsClient.GetById(id);
        }
    }
}