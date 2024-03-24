﻿namespace LabAppointmentSystem.API.Models
{
    public interface IAuditable
    {
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
        string ModifiedBy { get; set; }
    }
}
