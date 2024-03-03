using LabAppointmentSystem.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LabAppointmentSystem.API.Services.Classes
{
    public class ExceptionHandlingService : IExceptionHandlingService
    {
        private readonly ILogger<ExceptionHandlingService> _logger;

        public ExceptionHandlingService(ILogger<ExceptionHandlingService> logger)
        {
            _logger = logger;
        }

        public IActionResult HandleExceptionAsync(Exception exception)
        {
            _logger.LogError(exception, "An unhandled exception occurred.");

            return new ObjectResult("An internal server error occurred.")
            {
                StatusCode = 500
            };
        }
    }
}
