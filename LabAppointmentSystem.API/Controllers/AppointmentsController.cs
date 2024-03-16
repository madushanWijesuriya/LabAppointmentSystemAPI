using LabAppointmentSystem.API.Models;
using LabAppointmentSystem.API.Services.Classes;
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
        private readonly IAppointmentService _appointmentService;
        private readonly IExceptionHandlingService _exceptionHandlingService;

        public AppointmentsController(IAppointmentService appointmentService, IExceptionHandlingService exceptionHandlerExtensions)
        {
            _appointmentService = appointmentService;
            _exceptionHandlingService = exceptionHandlerExtensions;
        }

        [HttpPost]
        public async Task<IActionResult> create(Appointment appointment)
        {
            try
            {
                _appointmentService.CreateAppointment(appointment);
                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return BadRequest(_exceptionHandlingService.HandleExceptionAsync(ex));
            }
        }

        [HttpPost("Tests")]
        public async Task<IActionResult> assignTests(List<int> testIds, int appointmentId)
        {
            try
            {
                _appointmentService.AssignTests(testIds, appointmentId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(_exceptionHandlingService.HandleExceptionAsync(ex));
            }
        }
    }
}
