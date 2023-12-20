using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Organizations.Application.Interfaces;
using Organizations.Application.Utilities;

namespace Organizations.Application.Services;

public class TokenService : ITokenService
{
    private const string UserIdClaimName = "user_id";
    private const string Secret = "supermegasecretkey";
    
    private readonly IApplicationContext _context;

    public TokenService(IApplicationContext context)
    {
        _context = context;
    }

    public async Task<string> GetToken(string login, string password)
    {
        var passwordHash = Cipher.GetPasswordHash(password);
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Login == login && x.PasswordHash == passwordHash);
        if (user is null)
            throw new AuthenticationException("Invalid login or password.");
        
        var jwtTokenHandler = new JwtSecurityTokenHandler();

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        var identity = new ClaimsIdentity(new GenericIdentity(user.Login),
            new[] { new Claim(UserIdClaimName, user.Id.ToString()) });

        var token = jwtTokenHandler.CreateJwtSecurityToken(
            subject: identity,
            signingCredentials: signingCredentials,
            audience: "PlacesAudience",
            issuer: "PlacesIssuer",
            expires: DateTime.UtcNow.AddDays(1));

        return jwtTokenHandler.WriteToken(token);
    }
}