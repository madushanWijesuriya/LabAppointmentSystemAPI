using LabAppointmentSystem.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LabAppointmentSystem.API.Data
{
    public partial class AppDbContext
    {
        public DbSet<Appointment> Tests { get; set; }

        partial void OnModelCreatingTest(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>()
                .HasKey(at => new { at.Id });

            modelBuilder.Entity<Test>()
                .HasMany(a => a.AppointmentTests)
                .WithOne(at => at.Test)
                .HasForeignKey(at => at.TestId);
        }
    }
}
