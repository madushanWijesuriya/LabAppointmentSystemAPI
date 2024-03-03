using LabAppointmentSystem.API.Models;
using LabAppointmentSystem.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LabAppointmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _AppointmentService;
        private readonly IExceptionHandlingService _exceptionHandlingService;

        [HttpPost]
        public async Task<IActionResult> create(Appointment appointment)
        {
            try
            {
                _AppointmentService.CreateAppointment(appointment);
                return Ok(appointment);
            }catch (Exception ex)
            {
                return BadRequest(_exceptionHandlingService.HandleExceptionAsync(ex));
            }
        }
    }
}
