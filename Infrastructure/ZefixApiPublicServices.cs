using Application.DTOs;
using Application.Gateways;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Infrastructure
{
    public class ZefixApiPublicServices : IZefixApiPublicServices
    {
        private readonly HttpClient _httpClient;
        public ZefixApiPublicServices(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ZefixApi");
        }

        public async Task<IEnumerable<RegistryOfCommerceDTo>> GetRegistryOfCommerce()
        {
            var response = await _httpClient.GetAsync("registryOfCommerce");

            var content = await response.Content.ReadAsStringAsync();

            var contentResult = JsonSerializer.Deserialize<List<RegistryOfCommerceDTo>>(
                content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return contentResult ?? Enumerable.Empty<RegistryOfCommerceDTo>();
        }

        public async Task<IEnumerable<CompanyInfoDto>?> GetCompanyByUid(string Uid)
        {
            var response = await _httpClient.GetAsync($"company/uid/{Uid}");

            var content = await response.Content.ReadAsStringAsync();

            var jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                IgnoreReadOnlyProperties = true,
                UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip
            };

            var contentResult = JsonSerializer.Deserialize<List<CompanyInfoDto>>(content, jsonSerializerOptions);


            return contentResult;
        }
    }
}
