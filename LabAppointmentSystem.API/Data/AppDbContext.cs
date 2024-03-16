﻿using LabAppointmentSystem.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LabAppointmentSystem.API.Data
{

    public partial class AppDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public DbSet<Reception> Receptions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        partial void OnModelCreatingAppointment(ModelBuilder modelBuilder);
        partial void OnModelCreatingTest(ModelBuilder modelBuilder);
        partial void OnModelCreatingAppointmentTest(ModelBuilder modelBuilder);
        partial void OnModelCreatingTechnician(ModelBuilder modelBuilder);

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<string>>(b =>
            {
                b.HasKey(l => new { l.LoginProvider, l.ProviderKey });
            });

            OnModelCreatingTechnician(modelBuilder);
            OnModelCreatingAppointment(modelBuilder);
            OnModelCreatingTest(modelBuilder);
            OnModelCreatingAppointmentTest(modelBuilder);
        }
    }
}
