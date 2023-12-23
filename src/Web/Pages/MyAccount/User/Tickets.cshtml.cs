using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Dto;
using Web.Interfaces;

namespace Web.Pages.MyAccount.User;

public class TicketsModel : PageModel
{
    private readonly ITokenService _tokenService;

    public TicketsModel(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [BindProperty] 
    public IEnumerable<MyPaymentDto> MyPayments { get; set; } = Array.Empty<MyPaymentDto>();

    public IActionResult OnGet()
    {
        if (!_tokenService.IsAuthenticated())
            return RedirectToPage("/Auth/Login");
        
        if (_tokenService.IsOrganization())
            return RedirectToPage("/MyAccount/Organization/Index");
        
        //TODO: получение моих купленных билетов

        var test = new MyPaymentDto[]
        {
            new MyPaymentDto
            {
                Payment = new PaymentDto
                {
                    Price = 300,
                    ChangeDate = DateTime.Now
                },
                TicketType = new TicketTypeDto
                {
                    Title = "Dance floor",
                    Description = "Without seats."
                },
                Event = new EventDto
                {
                    Title = "Slava Marlow Concert",
                    Description = "The long-awaited Slava Marlow Concert big concert!",
                    Date = DateOnly.FromDateTime(DateTime.Now),
                    StartTime = TimeOnly.FromDateTime(DateTime.Now - TimeSpan.FromHours(1)),
                    EndTime = TimeOnly.FromDateTime(DateTime.Now + TimeSpan.FromHours(1)),
                    ImageName = "slava.jpg"
                },
                Organization = new OrganizationDto
                {
                    Name = "Crocus City Hall"
                }
            },

            new MyPaymentDto
            {
                Payment = new PaymentDto
                {
                    Price = 100,
                    ChangeDate = DateTime.Now
                },
                TicketType = new TicketTypeDto
                {
                    Title = "Some ticket",
                    Description = "Some description."
                },
                Event = new EventDto
                {
                    Title = "Orlov Concert",
                    Description = "The long-awaited Orlov big Stand-Up Concert!",
                    Date = DateOnly.FromDateTime(DateTime.Now),
                    StartTime = TimeOnly.FromDateTime(DateTime.Now - TimeSpan.FromHours(1)),
                    EndTime = TimeOnly.FromDateTime(DateTime.Now + TimeSpan.FromHours(1)),
                    ImageName = "orlov.png"
                },
                Organization = new OrganizationDto
                {
                    Name = "StandUp Club"
                }
            },
        };

        MyPayments = test;
        
        return Page();
    }
}