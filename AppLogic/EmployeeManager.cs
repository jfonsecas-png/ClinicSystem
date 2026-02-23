using DTO;
using System.Linq;
using System.Globalization;

namespace AppLogic
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IRHConnector _rhConnector;

        public EmployeeManager(IRHConnector rhConnector)
        {
            _rhConnector = rhConnector;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _rhConnector.RetrieveAllEmployees();
        }

        public async Task<Employee?> GetEmployeeById(int id)
        {
            var employees = await _rhConnector.RetrieveAllEmployees();

            return employees.FirstOrDefault(e => e.Id == id);
        }
        public async Task<Employee?> GetEmployeeManager(int employeeId)
        {
            var employees = await _rhConnector.RetrieveAllEmployees();

            var employee = employees.FirstOrDefault(e => e.Id == employeeId);

            if (employee == null || employee.ManagerId == null)
                return null;

            return employees.FirstOrDefault(e => e.Id == employee.ManagerId);
        }
        public async Task<List<Employee>> GetOldestEmployees()
        {
            var employees = await _rhConnector.RetrieveAllEmployees();

            var ordered = employees
                .Where(e => !string.IsNullOrEmpty(e.HiringDate))
                .OrderBy(e => DateTime.Parse(e.HiringDate))
                .ToList();

            if (!ordered.Any())
                return new List<Employee>();

            var oldestDate = DateTime.Parse(ordered.First().HiringDate);

            return ordered
                .Where(e => DateTime.Parse(e.HiringDate) == oldestDate)
                .ToList();
        }
        public async Task<List<Employee>> GetNewestEmployees()
        {
            var employees = await _rhConnector.RetrieveAllEmployees();

            var ordered = employees
                .Where(e => !string.IsNullOrEmpty(e.HiringDate))
                .OrderByDescending(e => DateTime.Parse(e.HiringDate))
                .ToList();

            if (!ordered.Any())
                return new List<Employee>();

            var newestDate = DateTime.Parse(ordered.First().HiringDate);

            return ordered
                .Where(e => DateTime.Parse(e.HiringDate) == newestDate)
                .ToList();
        }
    }

}