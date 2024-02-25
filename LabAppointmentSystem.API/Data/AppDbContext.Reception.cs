//using LabAppointmentSystem.API.Models;
//using Microsoft.EntityFrameworkCore;

//namespace LabAppointmentSystem.API.Data
//{
//    public partial class AppDbContext
//    {
//        public DbSet<Reception> Receptions { get; set; }

//        void ConfigureReceptionRelationships(ModelBuilder builder)
//        {

//            builder.Entity<Reception>()
//            .HasOne(p => p.User)
//            .WithOne()
//            .HasForeignKey<Reception>(p => p.UserId)
//            .IsRequired()
//            .OnDelete(DeleteBehavior.Cascade);

//        }
//    }
//}
