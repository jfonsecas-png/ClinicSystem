using AppLogic;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientManager _patientManager;

        public PatientsController(IPatientManager patientManager)
        {
            _patientManager = patientManager;
        }

        [HttpGet("GetAll")]
        public List<Patient> GetAll()
        {
            return _patientManager.GetAllPatients();
        }

        [HttpGet("GetById")]
        public Patient GetById(int id)
        {
            return _patientManager.GetPatientById(id);
        }
    }
}