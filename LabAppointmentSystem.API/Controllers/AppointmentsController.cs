using LabAppointmentSystem.API.Enums;
using LabAppointmentSystem.API.Mappers;
using LabAppointmentSystem.API.Models;
using LabAppointmentSystem.API.Payloads;
using LabAppointmentSystem.API.Services.Classes;
using LabAppointmentSystem.API.Services.Interfaces;
using LabInvoiceSystem.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;

namespace LabAppointmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : BaseController
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IInvoiceService _invoiceService;
        private readonly IExceptionHandlingService _exceptionHandlingService;
        private readonly UserManager<User> _userManageService;
        private readonly IUserService _userService;

        public AppointmentsController(IInvoiceService invoiceService,IAppointmentService appointmentService, IUserService userService,IExceptionHandlingService exceptionHandlerExtensions,
            UserManager<User> userManageService)
        {
            _appointmentService = appointmentService;
            _exceptionHandlingService = exceptionHandlerExtensions;
            _userManageService = userManageService;
            _userService = userService;
            _invoiceService = invoiceService;
        }

        [HttpGet("{role}")]
        [EnableQuery]
        public ActionResult<IEnumerable<Appointment>> GetAll(string role)
        {
            var appointments = _appointmentService.RetrievAllAppointments();

            if (role == "Technician")
            {
                appointments = appointments.Where(a => a.WorkFlow == AppointmentStatus.TestAssigned && a.AppointmentTests.Count() > 0);
            }
            else if (role == "Reception")
            {
                appointments = appointments.Where(a => a.WorkFlow != AppointmentStatus.TestAssigned);
            }
            else if (role == "Patient")
            {
                appointments = appointments.Where(a => a.PatientId == UserId);
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
                Time = appointment.Time,
                Invoice = appointment.Invoice,
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
                    Date = DateTime.SpecifyKind(appointment.Date,DateTimeKind.Unspecified),
                    Time = appointment.Time,
                    PatientId = UserId,
                    WorkFlow = AppointmentStatus.Created,
                    Status = Status.Active,
                };

                _appointmentService.CreateAppointment(model, UserId);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(_exceptionHandlingService.HandleExceptionAsync(ex));
            }
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "RequireStaff")]
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
                var storageAppointment = _appointmentService.GetAppointmentById(id);
                _appointmentService.UpdateAppointment(id, model, UserId);

                if (updatedAppointment.WorkFlow == AppointmentStatus.TestAssigned)
                {

                    if (storageAppointment.AppointmentTests.Count > 0)
                    {
                        double amount = 0;

                        foreach (var appointmentTest in storageAppointment.AppointmentTests)
                        {
                            amount = amount + appointmentTest.Test.Price;
                        }
                        var invoice = new Invoice
                        {
                            AppointmentId = id,
                            PatientId = storageAppointment.PatientId.ToString(),
                            Amount = amount
                        };

                        _invoiceService.CreateInvoice(invoice, UserId);
                        var insertedInvoice = _invoiceService.GetInvoiceByAppointmentId(invoice.AppointmentId);
                        storageAppointment.InvoiceId = insertedInvoice.Id;
                        _appointmentService.UpdateAppointment(id, storageAppointment, UserId);

                    }

                }
                else if (storageAppointment != null && storageAppointment.WorkFlow == AppointmentStatus.Verified)
                {
                    var user = await _userManageService.FindByIdAsync(storageAppointment.PatientId.ToString());
                    if (user != null)
                    {
                        var emailService = new AppointmentVerifiedEmailService();
                        emailService.createEmailBodyAndSendEmail(user, storageAppointment);
                    }
                }
                else if (updatedAppointment.WorkFlow == AppointmentStatus.TestCompleted)
                {
                    var user = await _userManageService.FindByIdAsync(storageAppointment.PatientId.ToString());
                    if (user != null)
                    {
                        var emailService = new PaymentReminderEmailService();
                        emailService.createEmailBodyAndSendEmail(user, storageAppointment);
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
        [Authorize]
        public async Task<IActionResult> assignTests(TestAssignRequest testAssign)
        {
            try
            {
                _appointmentService.AssignTests(testAssign.testIds, testAssign.appointmentId, UserId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(_exceptionHandlingService.HandleExceptionAsync(ex));
            }
        }

    }
}
