using LabAppointmentSystem.API.Models;
using LabAppointmentSystem.API.Services.Classes;
using LabAppointmentSystem.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabAppointmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IExceptionHandlingService _exceptionHandlingService;
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManageService;

        public UsersController(IExceptionHandlingService exceptionHandlingService,
            IUserService userService, UserManager<User> userManageService)
        {
            _userService = userService;
            _userManageService = userManageService;
            _exceptionHandlingService = exceptionHandlingService;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async ValueTask<ActionResult<IQueryable<User>>> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsers().ToListAsync();

                foreach (var user in users)
                {
                    var role = await _userManageService.GetRolesAsync(user);
                    user.Role = role.FirstOrDefault();
                }

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(_exceptionHandlingService.HandleExceptionAsync(ex));
            }
        }
    }
}
