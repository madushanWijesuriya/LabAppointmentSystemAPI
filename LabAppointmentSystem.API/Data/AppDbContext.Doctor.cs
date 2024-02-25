//using LabAppointmentSystem.API.Models;
//using Microsoft.EntityFrameworkCore;

//namespace LabAppointmentSystem.API.Data
//{
//    public partial class AppDbContext
//    {
//        public DbSet<Doctor> Doctors { get; set; }

//        void ConfigureDoctorRelationships(ModelBuilder builder)
//        {
//            builder.Entity<Doctor>()
//            .HasOne(p => p.User)
//            .WithOne()
//            .HasForeignKey<Doctor>(p => p.UserId)
//            .IsRequired()
//            .OnDelete(DeleteBehavior.Cascade);

//        }
//    }
//}
