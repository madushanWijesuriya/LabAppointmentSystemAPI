using LabAppointmentSystem.API.Models;
using LabAppointmentSystem.API.Payloads;
using LabAppointmentSystem.API.Services.Classes;
using LabAppointmentSystem.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace LabAppointmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentTestsController : ControllerBase
    {
        private readonly IAppointmentTestService _appointmentService;
        private readonly IExceptionHandlingService _exceptionHandlingService;

        public AppointmentTestsController(IAppointmentTestService appointmentTestService, IExceptionHandlingService exceptionHandlingService)
        {
            _appointmentService = appointmentTestService;
            _exceptionHandlingService = exceptionHandlingService;
        }
        [HttpGet("{appointmentId}")]
        [EnableQuery]
        public ActionResult<IEnumerable<AppointmentTest>> GetAll(int appointmentId)
        {
            try
            {
                var tests = _appointmentService.RetrievAllAppointmentTest(appointmentId).ToList();
                return Ok(tests);
            }
            catch (Exception ex)
            {
                return BadRequest(_exceptionHandlingService.HandleExceptionAsync(ex));
            }
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "RequireStaff")]
        public async Task<IActionResult> Update(int id, AppointmentTestPayload updatedAppointmentTest)
        {
            try
            {
                _appointmentService.UpdateAppointmentTest(id, updatedAppointmentTest);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(_exceptionHandlingService.HandleExceptionAsync(ex));
            }

        }

    }
}
