using LabAppointmentSystem.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LabAppointmentSystem.API.Data
{
    public partial class AppDbContext
    {
        public DbSet<AppointmentTest> AppointmentTests { get; set; }

        partial void OnModelCreatingAppointmentTest(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentTest>()
            .HasKey(at => new { at.AppointmentId, at.TestId });

            modelBuilder.Entity<AppointmentTest>()
                .HasOne(at => at.Appointment)
                .WithMany(a => a.AppointmentTests)
                .HasForeignKey(at => at.AppointmentId);

            modelBuilder.Entity<AppointmentTest>()
                .HasOne(at => at.Appointment)
                .WithMany(a => a.AppointmentTests)
                .HasForeignKey(at => at.AppointmentId);

                .WithMany(t => t.AppointmentTests)
                .HasForeignKey(at => at.TestId);
        }
    }
}
