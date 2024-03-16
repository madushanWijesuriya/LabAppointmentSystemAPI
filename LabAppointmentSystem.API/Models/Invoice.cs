﻿namespace LabAppointmentSystem.API.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string PatientId { get; set; }
        public int AppointmentId { get; set; }
        public double Amount { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Appointment Appointment { get; set; }
    }
}
