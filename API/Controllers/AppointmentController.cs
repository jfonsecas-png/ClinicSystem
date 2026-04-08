using AppLogic;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentManager _appointmentManager;

        public AppointmentController(IAppointmentManager appointmentManager)
        {
            _appointmentManager = appointmentManager;
        }

        [HttpPost("CreateAppointment")]
        public ApiResponse CreateAppointment(Appointment dto)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = _appointmentManager.CreateAppointment(dto);
                response.Result = "ok";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet("GetAppointmentsByPatientId")]
        public ApiResponse GetAppointmentsByPatientId(int patientId)
        {
            var response = new ApiResponse();
            try
            {
                //Lo mas importante
                // Leer el rol y patientId del token
                var role = User.FindFirst(ClaimTypes.Role)?.Value;
                var tokenPatientId = int.Parse(User.FindFirst("PatientId")?.Value ?? "0");

                // Si no es ADMIN y el patientId no coincide con el del token
                if (role != "ADMIN" && tokenPatientId != patientId)
                {
                    response.Result = "error";
                    response.Message = "Accion no permitida, valores ingresados inconcistentes.";
                    return response;
                }//

                response.Data = _appointmentManager.GetAppointmentsByPatientId(patientId);
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