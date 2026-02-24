using DTO;
using Newtonsoft.Json;
using RestSharp;

namespace AppLogic
{
    public class RHConnectorRestSharp : IRHConnector
    {
        private const string _baseUrl = "https://rh-central.azurewebsites.net/";

        public async Task<List<Employee>> RetrieveAllEmployees()
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("/api/RH/GetAllEmployees", Method.Get);

            var response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                return new List<Employee>();

            var employees = JsonConvert.DeserializeObject<List<Employee>>(response.Content);

            return employees;
        }

        public async Task<List<string>> RetrieveAllSpecialties()
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("/api/RH/GetSpecialties", Method.Get);

            var response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                return new List<string>();

            var specialties = JsonConvert.DeserializeObject<List<string>>(response.Content);

            return specialties;
        }
    }
}