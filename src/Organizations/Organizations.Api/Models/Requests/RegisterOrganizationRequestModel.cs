namespace Organizations.Api.Models.Requests;

public class RegisterOrganizationRequestModel : RegisterUserRequestModel
{
    public string Description { get; set; }
    
    public string Inn { get; set; }
    
    public string Ogrn { get; set; }
}