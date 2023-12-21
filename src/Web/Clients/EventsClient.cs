using System.Text;
using Newtonsoft.Json;
using Web.Dto;

namespace Web.Clients
{
    public class EventsClient
    {
        private readonly HttpClient _httpClient;

        public EventsClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(configuration["EventsBaseAddress"]!);
        }

        public async Task<IEnumerable<EventDto>?> Search(string? search)
        {
            var sb = new StringBuilder();
            sb.Append("search?");
            if (!string.IsNullOrWhiteSpace(search))
            {
                sb.Append($"search={search}");
            }
            var response = await _httpClient.GetAsync(sb.ToString());
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<EventDto>>(content);
        }

        public async Task<EventDto?> GetById(Guid id)
        {
            var response = await _httpClient.GetAsync($"{id}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<EventDto>(content);
        } 
    }
}