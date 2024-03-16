using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LabAppointmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected string UserId
        {
            get
            {
                return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }
        }
    }
}
