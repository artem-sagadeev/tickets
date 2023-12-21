namespace Web.Clients
{
    public class OrganizationsClient
    {
        private readonly HttpClient _httpClient;

        public OrganizationsClient(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(configuration["OrganizationsBaseAddress"]!);
        }
    }
}