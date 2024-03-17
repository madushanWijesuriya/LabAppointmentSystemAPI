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
        private readonly IExceptionHandlingService _exceptionHandlingService;

        public InvoiceController(IInvoiceService _invoiceService, IExceptionHandlingService exceptionHandlingService)
        {
            invoiceService = _invoiceService;
            _exceptionHandlingService = exceptionHandlingService;

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
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(_exceptionHandlingService.HandleExceptionAsync(ex));
            }
        }
    }
}
