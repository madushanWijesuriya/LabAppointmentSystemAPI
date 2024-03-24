using LabAppointmentSystem.API.Models;
using LabAppointmentSystem.API.Repositories;
using LabAppointmentSystem.API.Services.Interfaces;
using LabInvoiceSystem.API.Repositories;
using LabInvoiceSystem.API.Services.Interfaces;

namespace LabAppointmentSystem.API.Services.Classes
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IAuditService _auditService;

        public InvoiceService(IInvoiceRepository invoiceRepository, IAuditService auditService)
        {
            _invoiceRepository = invoiceRepository;
            _auditService = auditService;
        }
        public void CreateInvoice(Invoice invoiceDto, string modifiedBy)
        {
            _auditService.SetAuditFields(invoiceDto, modifiedBy);
            _invoiceRepository.SaveInvoice(invoiceDto);
        }

        public Invoice GetInvoiceByAppointmentId(int id)
        {
            return _invoiceRepository.GetAllInvoices().Where(a => a.AppointmentId == id).FirstOrDefault();
        }

        public IQueryable<Invoice> RetrievAllInvoices()
        {
            throw new NotImplementedException();
        }

        public void UpdateInvoice(Invoice updatedInvoice, string modifiedBy)
        {
            _auditService.SetAuditFields(updatedInvoice, modifiedBy);
            _invoiceRepository.UpdateInvoice(updatedInvoice);
        }
    }
}
