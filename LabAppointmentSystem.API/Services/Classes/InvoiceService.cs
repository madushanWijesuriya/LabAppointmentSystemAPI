using LabAppointmentSystem.API.Models;
using LabAppointmentSystem.API.Repositories;
using LabInvoiceSystem.API.Repositories;
using LabInvoiceSystem.API.Services.Interfaces;

namespace LabAppointmentSystem.API.Services.Classes
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }
        public void CreateInvoice(Invoice invoiceDto)
        {
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

        public void UpdateInvoice(Invoice updatedInvoice)
        {
            _invoiceRepository.UpdateInvoice(updatedInvoice);
        }
    }
}
