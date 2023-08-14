using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentRegistrationSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentRegistrationController : ControllerBase
    {
        [HttpGet]

        public async Task<ActionResult<List<StudentRegistration>>> GetStudentRegistration()
        {
            return new List<StudentRegistration>
            {
                new StudentRegistration
                {
                    FirstName = "Akthar",
                    LastName = "Farvee",
                    Mobile = "+94757649401",
                    Email = "akthar123@gmail.com",
                    DOB = "1998-12-10",
                    Address = "Colombo, Marudhana"

                }
            };
        }
    }
}
