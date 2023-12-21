namespace Web.Clients
{
    public class OrganizationsClient
    {
        private readonly HttpClient _httpClient;

        public OrganizationsClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(configuration["OrganizationsBaseAddress"]!);
        }

        public async Task<HttpResponseMessage> RegisterAsync(string login, string name, string password, string inn,
            string ogrn)
        {
            var requestModel = new { login, name, password, inn, ogrn };

            return await _httpClient.PostAsJsonAsync("register", requestModel);
        }
    }
}