using DTO;

namespace AppLogic
{
    public interface IEmployeeManager
    {
        Task<List<Employee>> GetAllEmployees();
    }
}