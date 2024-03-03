using LabAppointmentSystem.API.Dtos;
using LabAppointmentSystem.API.Models;
using LabAppointmentSystem.API.Services.Classes;
using LabAppointmentSystem.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LabAppointmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptionsController : ControllerBase
    {
        private readonly IReceptionService _ReceptionService;
        private readonly IExceptionHandlingService _exceptionHandlingService;
        private readonly UserManager<User> _userManageService;

        public ReceptionsController(
            IReceptionService ReceptionService, 
            UserManager<User> userManageService, 
            IExceptionHandlingService exceptionHandlingService)
        {
            _ReceptionService = ReceptionService;
            _userManageService = userManageService;
            _exceptionHandlingService = exceptionHandlingService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<IQueryable<Reception>> GetAllReceptions()
        {
            try
            {
                var Receptions = _ReceptionService.GetAllReceptions();
                return Ok(Receptions);
            }
            catch (Exception ex)
            {
                return BadRequest(_exceptionHandlingService.HandleExceptionAsync(ex));
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> create(Reception Reception)
        {
            try
            {
                var result = await _userManageService.CreateAsync(Reception, Reception.Password);

                if (result.Succeeded)
                {
                    await _userManageService.AddToRoleAsync(Reception, "Reception");
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
