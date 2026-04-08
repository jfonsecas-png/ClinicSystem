using AppLogic;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
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
        public ApiResponse GetAll()
        {
            var response = new ApiResponse();
            try
            {
                response.Data = _patientManager.GetAllPatients();
                response.Result = "ok";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet("GetById")]
        public ApiResponse GetById(int id)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = _patientManager.GetPatientById(id);
                response.Result = "ok";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }
            return response;
        }
    }
}