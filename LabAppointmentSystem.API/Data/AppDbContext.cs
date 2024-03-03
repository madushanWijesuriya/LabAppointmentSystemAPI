using LabAppointmentSystem.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LabAppointmentSystem.API.Data
{

    public partial class AppDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Reception> Receptions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        partial void OnModelCreatingAppointment(ModelBuilder modelBuilder);

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingAppointment(modelBuilder);
        }
    }
}
