using LabAppointmentSystem.API.Models;

namespace LabInvoiceSystem.API.Services.Interfaces
{
    public interface IInvoiceService
    {
        IQueryable<Invoice> RetrievAllInvoices();
        void CreateInvoice(Invoice invoiceDto);
        Invoice GetInvoiceById(int id);
        void UpdateInvoice(int invoiceId, Invoice updatedInvoice);

    }
}
