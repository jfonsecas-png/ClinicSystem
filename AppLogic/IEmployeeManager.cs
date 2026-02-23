using DTO;

namespace AppLogic
{
    public interface IEmployeeManager
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee?> GetEmployeeById(int id);
        Task<Employee?> GetEmployeeManager(int employeeId);
        Task<List<Employee>> GetOldestEmployees();
        Task<List<Employee>> GetNewestEmployees();
        Task<List<Employee>> GetEmployeesWithMoreThan(int years);
        Task<List<Employee>> GetEmployeesWithLessThan(int years);
    }
}