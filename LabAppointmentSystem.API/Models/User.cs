using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabAppointmentSystem.API.Models
{
    public class User : IdentityUser
    {
        public string? NIC { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public bool Gender { get; set; }
        [NotMapped]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
