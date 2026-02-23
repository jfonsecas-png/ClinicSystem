using DTO;

namespace AppLogic
{
    public interface IEmployeeManager
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee?> GetEmployeeById(int id);
        Task<Employee?> GetEmployeeManager(int employeeId);
    }
}