using LabAppointmentSystem.API.Enums;
using LabAppointmentSystem.API.Models;
using LabAppointmentSystem.API.Payloads;
using LabAppointmentSystem.API.Services.Classes;
using LabAppointmentSystem.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace LabAppointmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentTestsController : BaseController
    {
        private readonly IAppointmentTestService _appointmentService;
        private readonly IExceptionHandlingService _exceptionHandlingService;
        private readonly IUserService _userService;
        private readonly IAppointmentService _appService;
        private readonly UserManager<User> _userManageService;

        public AppointmentTestsController(IAppointmentTestService appointmentTestService, IExceptionHandlingService exceptionHandlingService,
            IUserService userService, UserManager<User> userManageService, IAppointmentService appService)
        {
            _appointmentService = appointmentTestService;
            _exceptionHandlingService = exceptionHandlingService;
            _userService = userService;
            _userManageService = userManageService;
            _appService = appService;

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
        [Authorize(Roles = "Technician")]
        public async Task<IActionResult> Update(int id, AppointmentTestPayload updatedAppointmentTest)
        {
            try
            {
                var userId = UserId;
                _appointmentService.UpdateAppointmentTest(userId, id, updatedAppointmentTest, UserId);
                
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(_exceptionHandlingService.HandleExceptionAsync(ex));
            }

        }

    }
}
