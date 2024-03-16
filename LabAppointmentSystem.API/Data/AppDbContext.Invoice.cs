using LabAppointmentSystem.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LabAppointmentSystem.API.Data
{
    public partial class AppDbContext
    {
        public DbSet<Invoice> Invoices { get; set; }
        partial void OnModelCreatingInvoice(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>()
                .HasKey(at => new { at.Id });

            modelBuilder.Entity<Invoice>()
                .HasOne(a => a.Patient)
                .WithMany(at => at.Invoices)
                .HasForeignKey(at => at.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Invoice>()
                .HasOne(a => a.Appointment)
                .WithOne(at => at.Invoice)
                .HasForeignKey<Invoice>(i => i.AppointmentId);
        }
    }
}
