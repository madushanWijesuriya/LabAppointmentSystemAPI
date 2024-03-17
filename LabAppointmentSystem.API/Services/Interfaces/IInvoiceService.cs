using LabAppointmentSystem.API.Models;

namespace LabInvoiceSystem.API.Services.Interfaces
{
    public interface IInvoiceService
    {
        IQueryable<Invoice> RetrievAllInvoices();
        void CreateInvoice(Invoice invoiceDto);
        Invoice GetInvoiceByAppointmentId(int id);
        void UpdateInvoice(Invoice updatedInvoice);

    }
}
