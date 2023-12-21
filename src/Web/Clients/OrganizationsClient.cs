using Newtonsoft.Json;
using Web.Dto;

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

        public async Task<OrganizationDto?> GetById(Guid id)
        {
            var url = $"api/organizations/{id}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<OrganizationDto>(content);
        }
    }
}