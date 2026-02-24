using DTO;
using Flurl.Http;

namespace AppLogic
{
    public class RHConnectorFlurl : IRHConnector
    {
        private const string _baseUrl = "https://rh-central.azurewebsites.net";

        public async Task<List<Employee>> RetrieveAllEmployees()
        {
            try
            {
                return await $"{_baseUrl}/api/RH/GetAllEmployees"
                    .GetJsonAsync<List<Employee>>();
            }
            catch
            {
                return new List<Employee>();
            }
        }

        public async Task<List<string>> RetrieveAllSpecialties()
        {
            try
            {
                return await $"{_baseUrl}/api/RH/GetSpecialties"
                    .GetJsonAsync<List<string>>();
            }
            catch
            {
                return new List<string>();
            }
        }
    }
}