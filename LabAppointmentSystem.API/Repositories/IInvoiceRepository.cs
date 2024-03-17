using LabAppointmentSystem.API.Models;

namespace LabInvoiceSystem.API.Repositories
{
    public interface IInvoiceRepository
    {
        IQueryable<Invoice> GetAllInvoices();
        void SaveInvoice(Invoice invoice);
        void UpdateInvoice(Invoice updatedInvoice);
    }
}
