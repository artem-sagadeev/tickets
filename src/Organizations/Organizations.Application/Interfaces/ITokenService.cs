namespace Organizations.Application.Interfaces;

public interface ITokenService
{
    Task<string> GetToken(string login, string password);
}