using LabAppointmentSystem.API.Models;
using LabAppointmentSystem.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LabTestSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly IExceptionHandlingService _exceptionHandlingService;

        public TestsController(ITestService testService, IExceptionHandlingService exceptionHandlingService)
        {
            _testService = testService;
            _exceptionHandlingService = exceptionHandlingService;
        }

        [HttpPost]
        public async Task<IActionResult> create(Test Test)
        {
            try
            {
                _testService.CreateTest(Test);
                return Ok(Test);
            }
            catch (Exception ex)
            {
                return BadRequest(_exceptionHandlingService.HandleExceptionAsync(ex));
            }
        }
    }
}
