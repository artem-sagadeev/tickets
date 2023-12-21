using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Interfaces;

namespace Web.Pages.Auth;

public class LoginModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ITokenService _tokenService;

    public LoginModel(
        IHttpClientFactory httpClientFactory, 
        ITokenService tokenService)
    {
        _httpClientFactory = httpClientFactory;
        _tokenService = tokenService;
    }

    [BindProperty] 
    [Required]
    public string Login { get; set; } = string.Empty;

    [BindProperty] 
    [Required]
    public string Password { get; set; } = string.Empty;

    public string ErrorMessage = string.Empty;

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();
        
        var client = _httpClientFactory.CreateClient();
        
        var requestModel = new { Login, Password };
        //TODO: requestUri
        var response = await client.PostAsJsonAsync("http://localhost:5066/api/Auth/Login", requestModel);
            
        if (response.IsSuccessStatusCode)
        {
            var token = await response.Content.ReadAsStringAsync();
            _tokenService.SaveToken(token);
            
            return RedirectToPage("/Index");
        }

        ErrorMessage = response.StatusCode == System.Net.HttpStatusCode.Unauthorized
            ? await response.Content.ReadAsStringAsync()
            : "An error occurred while processing your request.";

        return Page();
    }
}