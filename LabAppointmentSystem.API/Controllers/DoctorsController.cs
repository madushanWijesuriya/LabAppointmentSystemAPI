﻿using LabAppointmentSystem.API.Models;
using LabAppointmentSystem.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LabAppointmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IExceptionHandlingService _exceptionHandlingService;
        private readonly UserManager<User> _userManageService;

        public DoctorsController(
            IDoctorService doctorService, 
            UserManager<User> userManageService, 
            IExceptionHandlingService exceptionHandlingService)
        {
            _doctorService = doctorService;
            _userManageService = userManageService;
            _exceptionHandlingService = exceptionHandlingService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<IQueryable<Doctor>> GetAllDoctors()
        {
            try
            {
                var doctors = _doctorService.GetAllDoctors();
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return BadRequest(_exceptionHandlingService.HandleExceptionAsync(ex));
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> create(Doctor doctor)
        {
            try
            {
                var result = await _userManageService.CreateAsync(doctor, doctor.Password);

                if (result.Succeeded)
                {
                    await _userManageService.AddToRoleAsync(doctor, "Doctor");
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
