using Microsoft.AspNetCore.Identity;

namespace LabAppointmentSystem.API.Models
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        public string NIC { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Tel { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
