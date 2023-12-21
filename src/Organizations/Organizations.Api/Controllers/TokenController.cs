using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc;
using Organizations.Api.Models.Requests;
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
    
    [HttpPost]
    public async Task<ActionResult<string>> Get(GetTokenRequestModel model)
    {
        try
        {
            var token = await _tokenService.GetToken(model.Login, model.Password);

            return Ok(token);
        }
        catch (AuthenticationException e)
        {
            return Unauthorized(e.Message);
        }
    }
}