using DTO;

namespace AppLogic
{
    public interface IRHConnector
    {
        Task<List<Employee>> RetrieveAllEmployees();
        Task<List<string>> RetrieveAllSpecialties();
    }
}