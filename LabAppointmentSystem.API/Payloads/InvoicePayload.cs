namespace LabAppointmentSystem.API.Payloads
{
    public class InvoicePayload 
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public double Amount { get; set; }
    }
}
