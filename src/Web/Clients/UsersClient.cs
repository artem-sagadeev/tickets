namespace Web.Clients;

public class UsersClient
{
    private readonly HttpClient _httpClient;

    public UsersClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClient = httpClientFactory.CreateClient();
        _httpClient.BaseAddress = new Uri(configuration["UsersBaseAddress"]!);
    }
    
    public async Task<HttpResponseMessage> RegisterAsync(string login, string name, string password)
    {
        var requestModel = new { login, name, password };

        return await _httpClient.PostAsJsonAsync("register", requestModel);
    }
}