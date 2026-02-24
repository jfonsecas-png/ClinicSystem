using DTO;
using Newtonsoft.Json;

namespace AppLogic
{
    public class RHConnectorHttpClient : IRHConnector
    {
        private static HttpClient _httpClient;
        private const string _baseUrl = "https://rh-central.azurewebsites.net/";

        public RHConnectorHttpClient()
        {
            if (_httpClient == null)
            {
                _httpClient = new HttpClient()
                {
                    BaseAddress = new Uri(_baseUrl),
                    Timeout = TimeSpan.FromSeconds(15)
                };
            }
        }

        public async Task<List<Employee>> RetrieveAllEmployees()
        {
            string serviceUrl = "/api/RH/GetAllEmployees";
            string result = await InvokeGetAsync(serviceUrl);

            return JsonConvert.DeserializeObject<List<Employee>>(result);
        }

        public async Task<List<string>> RetrieveAllSpecialties()
        {
            string serviceUrl = "/api/RH/GetSpecialties";
            string result = await InvokeGetAsync(serviceUrl);

            return JsonConvert.DeserializeObject<List<string>>(result);
        }

        private async Task<string> InvokeGetAsync(string uri)
        {
            var response = await _httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            return string.Empty;
        }
    }
}