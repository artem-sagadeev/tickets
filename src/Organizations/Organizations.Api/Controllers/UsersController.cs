using Microsoft.AspNetCore.Mvc;
using Organizations.Api.Models;
using Organizations.Application.Dto;
using Organizations.Application.Interfaces;

namespace Organizations.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{userId:guid}")]
    public async Task<ActionResult<UserDto>> GetUser(Guid userId)
    {
        var user = await _userService.GetById(userId);
        
        return user is null ? NotFound() : Ok(user);
    }
    
    [HttpPost]
    public async Task<Guid> CreateUser(CreateUserModel model)
    {
        return await _userService.Create(model.Login, model.Name, model.PasswordHash);
    }
}