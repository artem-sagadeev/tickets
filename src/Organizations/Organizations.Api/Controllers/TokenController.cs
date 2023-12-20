using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc;
using Organizations.Application.Interfaces;

namespace Organizations.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TokenController : ControllerBase
{
    private readonly ITokenService _tokenService;

    public TokenController(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }
    
    [HttpGet]
    public async Task<ActionResult<string>> Get(string login, string password)
    {
        try
        {
            var token = await _tokenService.GetToken(login, password);

            return Ok(token);
        }
        catch (AuthenticationException e)
        {
            return Unauthorized(e.Message);
        }
    }
}