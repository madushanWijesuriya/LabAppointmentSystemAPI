using LabAppointmentSystem.API.Enums;
using LabAppointmentSystem.API.Models;
using LabAppointmentSystem.API.Payloads;
using LabAppointmentSystem.API.Services.Classes;
using LabAppointmentSystem.API.Services.Interfaces;
using LabInvoiceSystem.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabAppointmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService invoiceService;
        private readonly IAppointmentService _appointmentService;
        private readonly IExceptionHandlingService _exceptionHandlingService;

        public InvoiceController(IInvoiceService _invoiceService, IExceptionHandlingService exceptionHandlingService, IAppointmentService appointmentService)
        {
            invoiceService = _invoiceService;
            _exceptionHandlingService = exceptionHandlingService;
            _appointmentService = appointmentService;

        }
        [HttpGet("{appointmentId}")]
        public ActionResult<Invoice> InvoiceGetByAppointmentId(int appointmentId)
        {
            try
            {
                var invoice = invoiceService.GetInvoiceByAppointmentId(appointmentId);
                return Ok(invoice);
            }
            catch (Exception ex)
            {
                return BadRequest(_exceptionHandlingService.HandleExceptionAsync(ex));
            }
        }

        [HttpPut()]
        public ActionResult UpdateInvoice(InvoicePayload invoice)
        {
            try
            {
                var updatedInvoice = new Invoice
                {
                    Id = invoice.Id,
                    Amount = invoice.Amount
                };
                invoiceService.UpdateInvoice(updatedInvoice);

                var appointment = _appointmentService.GetAppointmentById(invoice.AppointmentId);
                appointment.WorkFlow = AppointmentStatus.Paid;
                _appointmentService.UpdateAppointment(appointment.Id, appointment);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(_exceptionHandlingService.HandleExceptionAsync(ex));
            }
        }
    }
}
