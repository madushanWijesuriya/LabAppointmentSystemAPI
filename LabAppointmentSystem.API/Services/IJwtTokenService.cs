﻿using LabAppointmentSystem.API.Models;

namespace LabAppointmentSystem.API.Services
{
    public interface IJwtTokenService
    {
        string GenerateJwtToken(User user, IList<string> roles);
        string GenerateJwtToken(User user);
    }
}
