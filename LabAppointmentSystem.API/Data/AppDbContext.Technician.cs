using LabAppointmentSystem.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LabAppointmentSystem.API.Data
{
    public partial class AppDbContext
    {
        public DbSet<Technician> Technicians { get; set; }

        partial void OnModelCreatingTechnician(ModelBuilder modelBuilder)
        {
            

            //modelBuilder.Entity<Technician>()
            //    .HasMany(a => a.AppointmentTests)
            //    .WithOne(at => at.Technician)
            //    .HasForeignKey(at => at.TechnicianId);

        }
    }
}
