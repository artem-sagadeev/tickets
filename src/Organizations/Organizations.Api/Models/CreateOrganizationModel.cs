namespace Organizations.Api.Models;

public class CreateOrganizationModel : CreateUserModel
{
    public string Description { get; set; }
    
    public string Inn { get; set; }
    
    public string Ogrn { get; set; }
}