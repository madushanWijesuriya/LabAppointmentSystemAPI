using LabAppointmentSystem.API.Data;
using LabAppointmentSystem.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LabInvoiceSystem.API.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext _dbContext;
        public InvoiceRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Invoice> GetAllInvoices() => _dbContext.Invoices.Include(r => r.Appointment)
            .Include(r => r.Patient);

        public Invoice GetInvoice(int id)
        {
            return _dbContext.Invoices.Find(id);
        }

        public void SaveInvoice(Invoice Invoice)
        {
            _dbContext.Invoices.Add(Invoice);
            _dbContext.SaveChanges();
        }

        public void UpdateInvoice(int id, Invoice updatedInvoice)
        {
            throw new NotImplementedException();
        }
    }
}
