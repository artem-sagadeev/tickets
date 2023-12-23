﻿namespace Web.Clients
{
    public class PaymentsClient
    {
        private readonly HttpClient _httpClient;

        public PaymentsClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(configuration["PaymentsBaseAddress"]!);
        }

        public async Task<bool> Buy(Guid ticketTypeId, Guid userId)
        {
            var request = new { ticketTypeId, userId };
            var response = await _httpClient.PostAsJsonAsync("buy", request);
            var content = await response.Content.ReadAsStringAsync();

            return bool.Parse(content);
        }
    }
}