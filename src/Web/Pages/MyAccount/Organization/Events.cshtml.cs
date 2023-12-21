using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Clients;
using Web.Dto;
using Web.Interfaces;

namespace Web.Pages.MyAccount.Organization;

public class EventsModel : PageModel
{
    private readonly ITokenService _tokenService;
    private readonly EventsClient _eventsClient;

    public EventsModel(ITokenService tokenService, EventsClient eventsClient)
    {
        _tokenService = tokenService;
        _eventsClient = eventsClient;
    }

    [BindProperty] public IEnumerable<EventDto> Events { get; set; } = Array.Empty<EventDto>();
    
    public async Task<IActionResult> OnGet()
    {
        if (!_tokenService.IsOrganization())
            return RedirectToPage("/Auth/Login");
        
        var organizationId = _tokenService.GetUserId();
        //TODO: получать все мои события
        var events = await _eventsClient.GetByOrganizationIdAsync(new Guid(organizationId!));
        Events = events?.OrderByDescending(x => x.Date).ToArray() ?? Array.Empty<EventDto>();
        
        return Page();
    }
}