using DTO;
using System.Linq;

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
    }
}