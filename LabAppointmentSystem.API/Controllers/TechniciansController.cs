using LabAppointmentSystem.API.Models;
using LabAppointmentSystem.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LabAppointmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechniciansController : ControllerBase
    {
        private readonly ITechnicianService _Technicianservice;
        private readonly IExceptionHandlingService _exceptionHandlingService;
        private readonly UserManager<User> _userManageService;

        public TechniciansController(
            ITechnicianService Technicianservice, 
            UserManager<User> userManageService, 
            IExceptionHandlingService exceptionHandlingService)
        {
            _Technicianservice = Technicianservice;
            _userManageService = userManageService;
            _exceptionHandlingService = exceptionHandlingService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<IQueryable<Technician>> GetAllTechnicians()
        {
            try
            {
                var Technicians = _Technicianservice.GetAllTechnicians();
                return Ok(Technicians);
            }
            catch (Exception ex)
            {
                return BadRequest(_exceptionHandlingService.HandleExceptionAsync(ex));
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> create(Technician Technician)
        {
            try
            {
                var result = await _userManageService.CreateAsync(Technician, Technician.Password);

                if (result.Succeeded)
                {
                    await _userManageService.AddToRoleAsync(Technician, "Technician");
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(_exceptionHandlingService.HandleExceptionAsync(ex));
            }
        }

    }
}
