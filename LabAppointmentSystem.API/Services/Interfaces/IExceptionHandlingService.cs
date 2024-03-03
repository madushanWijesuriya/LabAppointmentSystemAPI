using Microsoft.AspNetCore.Mvc;

namespace LabAppointmentSystem.API.Services.Interfaces
{
    public interface IExceptionHandlingService
    {
        IActionResult HandleExceptionAsync(Exception exception);
    }
}
