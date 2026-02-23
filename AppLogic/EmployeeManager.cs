using DTO;

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
    }
}