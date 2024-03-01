using LabAppointmentSystem.API.Dtos;
using LabAppointmentSystem.API.Models;
using LabAppointmentSystem.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LabAppointmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly UserManager<User> _userManageService;

        public DoctorsController(IDoctorService doctorService, UserManager<User> userManageService)
        {
            _doctorService = doctorService;
            _userManageService = userManageService;
        }

        [HttpGet]
        [Authorize(Roles = "Doctor")]
        public ActionResult<IQueryable<Doctor>> GetAllDoctors()
        {
            var doctors = _doctorService.GetAllDoctors();
            return Ok(doctors);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> create(Doctor doctor)
        {
            var result = await _userManageService.CreateAsync(doctor, doctor.Password);

            if (result.Succeeded)
            {
                await _userManageService.AddToRoleAsync(doctor, "Doctor");
                return Ok();
            }

            return BadRequest(result.Errors);
        }

    }
}
