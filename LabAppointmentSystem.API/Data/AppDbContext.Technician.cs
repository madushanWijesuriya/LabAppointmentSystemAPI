//using LabAppointmentSystem.API.Models;
//using Microsoft.EntityFrameworkCore;

//namespace LabAppointmentSystem.API.Data
//{
//    public partial class AppDbContext
//    {
//        public DbSet<Technician> Technician { get; set; }

//        void ConfigureTechnicianRelationships(ModelBuilder builder)
//        {

//            builder.Entity<Technician>()
//            .HasOne(p => p.User)
//            .WithOne()
//            .HasForeignKey<Technician>(p => p.UserId)
//            .IsRequired()
//            .OnDelete(DeleteBehavior.Cascade);

//        }
//    }
//}
