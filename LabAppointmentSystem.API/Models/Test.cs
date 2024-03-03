namespace LabAppointmentSystem.API.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public ICollection<AppointmentTest> AppointmentTests { get; set; }
    }
}
