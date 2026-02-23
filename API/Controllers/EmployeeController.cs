using AppLogic;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        [HttpGet("GetAll")]
        public async Task<List<Employee>> GetAll()
        {
            return await _employeeManager.GetAllEmployees();
        }
        [HttpGet("GetById")]
        public async Task<Employee?> GetById(int id)
        {
            return await _employeeManager.GetEmployeeById(id);
        }
        [HttpGet("GetManager")]
        public async Task<Employee?> GetManager(int employeeId)
        {
            return await _employeeManager.GetEmployeeManager(employeeId);
        }
        [HttpGet("GetOldest")]
        public async Task<List<Employee>> GetOldest()
        {
            return await _employeeManager.GetOldestEmployees();
        }

        [HttpGet("GetNewest")]
        public async Task<List<Employee>> GetNewest()
        {
            return await _employeeManager.GetNewestEmployees();
        }
    }
}