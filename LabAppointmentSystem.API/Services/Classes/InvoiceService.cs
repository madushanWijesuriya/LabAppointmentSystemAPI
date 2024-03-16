using LabAppointmentSystem.API.Models;
using LabInvoiceSystem.API.Services.Interfaces;

namespace LabAppointmentSystem.API.Services.Classes
{
    public class InvoiceService : IInvoiceService
    {
        public void CreateInvoice(Invoice invoiceDto)
        {
            throw new NotImplementedException();
        }

        public Invoice GetInvoiceById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Invoice> RetrievAllInvoices()
        {
            throw new NotImplementedException();
        }

        public void UpdateInvoice(int invoiceId, Invoice updatedInvoice)
        {
            throw new NotImplementedException();
        }
    }
}
