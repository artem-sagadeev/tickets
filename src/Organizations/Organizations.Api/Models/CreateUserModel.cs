namespace Organizations.Api.Models;

public class CreateUserModel
{
    public string Login { get; set; }
    
    public string Name { get; set; }
    
    public string PasswordHash { get; set; }
}