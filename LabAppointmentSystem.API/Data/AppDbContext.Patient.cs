//using LabAppointmentSystem.API.Models;
//using Microsoft.EntityFrameworkCore;

//namespace LabAppointmentSystem.API.Data
//{
//    public partial class AppDbContext
//    {
//        public DbSet<Patient> Patients { get; set; }

//        void ConfigurePatientRelationships(ModelBuilder builder)
//        {

//         builder.Entity<Patient>()
//            .HasOne(p => p.User)
//            .WithOne()
//            .HasForeignKey<Patient>(p => p.UserId)
//            .IsRequired()
//            .OnDelete(DeleteBehavior.Cascade);
//        }
//    }
//}
