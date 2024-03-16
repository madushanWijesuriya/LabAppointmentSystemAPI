using LabAppointmentSystem.API.Enums;
using LabAppointmentSystem.API.Mappers;
using LabAppointmentSystem.API.Models;
using LabAppointmentSystem.API.Payloads;
using LabAppointmentSystem.API.Services.Classes;
using LabAppointmentSystem.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace LabAppointmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : BaseController
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IExceptionHandlingService _exceptionHandlingService;
        private readonly UserManager<User> _userManageService;
        private readonly IUserService _userService;

        public AppointmentsController(IAppointmentService appointmentService, IUserService userService,IExceptionHandlingService exceptionHandlerExtensions,
            UserManager<User> userManageService)
        {
            _appointmentService = appointmentService;
            _exceptionHandlingService = exceptionHandlerExtensions;
            _userManageService = userManageService;
            _userService = userService;
        }

        [HttpGet("{role}")]
        [EnableQuery]
        public ActionResult<IEnumerable<Appointment>> GetAll(string role)
        {
            var appointments = _appointmentService.RetrievAllAppointments();

            if (role == "Technician")
            {
                appointments = appointments.Where(a => a.WorkFlow == AppointmentStatus.CheckIn);
            }
            else if (role == "Reception")
            {
                appointments = appointments.Where(a => a.WorkFlow != AppointmentStatus.CheckIn);
            }

            var appointmentDtos = appointments.Select(appointment => new Appointment
            {
                Id = appointment.Id,
                FormatedTime = appointment.Time >= 0 ? appointment.Time.ToString("F2") : null,
                Status = appointment.Status,
                WorkFlow = appointment.WorkFlow,
                Date = appointment.Date,
                AppointmentTests = appointment.AppointmentTests,
                PatientId = appointment.PatientId,
                Time = appointment.Time
            });
            return Ok(appointmentDtos);
        }

        [HttpPost]
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> create(AppointmentPayload appointment)
        {
            try
            {
                var model = new Appointment
                {
                    Date = DateTime.Now.Date,
                    Time = 12.30,
                    PatientId = UserId,
                    WorkFlow = AppointmentStatus.Created,
                    Status = Status.Active,
                };

                _appointmentService.CreateAppointment(model);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(_exceptionHandlingService.HandleExceptionAsync(ex));
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, AppointmentPayload updatedAppointment)
        {
            try
            {
                var model = new Appointment
                {
                    Id = id,
                    Date = updatedAppointment.Date,
                    Time = updatedAppointment.Time,
                    WorkFlow = updatedAppointment.WorkFlow,
                    Status = updatedAppointment.Status
                };

                _appointmentService.UpdateAppointment(id, model);
                var storageAppointment = _appointmentService.GetAppointmentById(id);

                if (storageAppointment != null && storageAppointment.WorkFlow == AppointmentStatus.Verified)
                {
                    var user = await _userManageService.FindByIdAsync(storageAppointment.PatientId.ToString());
                    if (user != null)
                    {
                        var userEmail = user.Email;
                        var emailService = new EmailService();
                        var emailBody = $"Hi {user.Name},\n\n" +
                        $"This is a reminder that your appointment is now in progress. " +
                        $"Please make sure to pay the full amount to proceed.\n\n" +
                        $"Appointment Details:\n" +
                        $"Id: {storageAppointment.Id}\n" +
                        $"Date: {storageAppointment.Date}\n" +
                        $"Time: {storageAppointment.Time}\n" +
                        $"Thank you for choosing our services.\n\n" +
                        $"Best regards,\n" +
                        $"ICBT Appointment Lab";
                        emailService.SendEmail(userEmail, "ICBT Lab Payment Reminder", emailBody);
                    }
                }

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(_exceptionHandlingService.HandleExceptionAsync(ex));
            }
        }


        [HttpPost("Tests")]
        public async Task<IActionResult> assignTests(TestAssignRequest testAssign)
        {
            try
            {
                _appointmentService.AssignTests(testAssign.testIds, testAssign.appointmentId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(_exceptionHandlingService.HandleExceptionAsync(ex));
            }
        }


    }
}
