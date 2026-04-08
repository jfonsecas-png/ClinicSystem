using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        [HttpGet("Get")]
        public string GetDoctor()
        {
            return "Doctor information";
        }

        [HttpGet("GetAll")]
        public string GetAllDoctors()
        {
            return "List of all doctors";
        }

        [HttpGet("GetById")]
        public string GetById(int id)
        {
            return "Doctor with id " + id;
        }
    }
}