using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Auth;

public class RegisterUserModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;
    
    [BindProperty]
    [Required]
    public string Login { get; set; } = string.Empty;

    [BindProperty]
    [Required]
    public string Name { get; set; } = string.Empty;
    
    [BindProperty]
    [Required]
    public string Password { get; set; } = string.Empty;

    [BindProperty]
    [Required]
    [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; } = string.Empty;

    public string ErrorMessage = string.Empty;

    public RegisterUserModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();
        
        var client = _httpClientFactory.CreateClient();
        
        var requestModel = new { Login, Name, Password };
        //TODO: requestUri
        var response = await client.PostAsJsonAsync("http://localhost:5066/api/Users/Register", requestModel);

        if (response.IsSuccessStatusCode)
            return RedirectToPage("/Auth/Login");

        ErrorMessage = response.StatusCode == System.Net.HttpStatusCode.Conflict
            ? await response.Content.ReadAsStringAsync()
            : "An error occurred while processing your request.";

        return Page();
    }
}