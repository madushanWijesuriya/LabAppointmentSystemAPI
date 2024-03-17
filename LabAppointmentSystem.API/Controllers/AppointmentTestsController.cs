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
                _appointmentService.UpdateAppointmentTest(userId, id, updatedAppointmentTest);
                //var storageAppointment = _appService.GetAppointmentById(id);

                //if(storageAppointment != null && storageAppointment.WorkFlow == AppointmentStatus.TestCompleted)
                //{
                //    var user = await _userManageService.FindByIdAsync(storageAppointment.PatientId.ToString());
                //    if (user != null)
                //    {
                //        var userEmail = user.Email;
                //        var emailService = new EmailService();
                //        var emailBody = $"Hi {user.Name},\n\n" +
                //        $"This is a reminder that your appointment test result is out. " +
                //        $"Please make sure to pay the full amount to view results.\n\n" +
                //        $"Appointment Details:\n" +
                //        $"Id: {storageAppointment.Id}\n" +
                //        $"Date: {storageAppointment.Date}\n" +
                //        $"Time: {storageAppointment.Time}\n" +
                //        $"Thank you for choosing our services.\n\n" +
                //        $"Best regards,\n" +
                //        $"ICBT Appointment Lab";
                //        emailService.SendEmail(userEmail, "ICBT Lab Payment Reminder", emailBody);
                //    }
                //}

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(_exceptionHandlingService.HandleExceptionAsync(ex));
            }

        }

    }
}
