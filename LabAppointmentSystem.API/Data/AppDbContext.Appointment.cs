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
                .HasMany(a => a.AppointmentTests)
                .WithOne(at => at.Appointment)
                .HasForeignKey(at => at.AppointmentId);
        }
    }
}
