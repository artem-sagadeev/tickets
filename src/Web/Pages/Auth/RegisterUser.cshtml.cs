using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Clients;

namespace Web.Pages.Auth;

public class RegisterUserModel : PageModel
{
    private readonly UsersClient _usersClient;
    
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

    public RegisterUserModel(UsersClient usersClient)
    {
        _usersClient = usersClient;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();
        
        var response = await _usersClient.RegisterAsync(Login, Name, Password);

        if (response.IsSuccessStatusCode)
            return RedirectToPage("/Auth/Login");

        ErrorMessage = response.StatusCode == System.Net.HttpStatusCode.Conflict
            ? await response.Content.ReadAsStringAsync()
            : "An error occurred while processing your request.";

        return Page();
    }
}