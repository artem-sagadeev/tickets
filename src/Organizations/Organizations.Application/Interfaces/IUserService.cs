using Organizations.Application.Dto;

namespace Organizations.Application.Interfaces;

public interface IUserService
{
    Task<UserDto?> GetById(Guid userId);
    
    Task<Guid> Create(string login, string name, string passwordHash);
}