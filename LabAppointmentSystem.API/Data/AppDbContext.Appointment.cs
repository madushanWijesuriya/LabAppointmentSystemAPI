using LabAppointmentSystem.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LabAppointmentSystem.API.Data
{
    public partial class AppDbContext
    {
        public DbSet<Appointment> Appointments { get; set; }

        partial void OnModelCreatingAppointment(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasKey(at => new { at.Id });

            modelBuilder.Entity<Appointment>()
                .HasMany(a => a.AppointmentTests)
                .WithOne(at => at.Appointment)
                .HasForeignKey(at => at.AppointmentId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);

            modelBuilder.Entity<Appointment>()
                .HasOne(at => at.Invoice) 
                .WithOne(i => i.Appointment) 
                .HasForeignKey<Appointment>(i => i.InvoiceId); 

        }
    }
}
