using LabAppointmentSystem.API.Models;
using LabAppointmentSystem.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LabAppointmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    [Authorize]

    public class AuthController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IConfiguration _config;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IJwtTokenService jwtTokenService, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenService = jwtTokenService;
            _config = config;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(User model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var roles = await _userManager.GetRolesAsync(user);

                var token = _jwtTokenService.GenerateJwtToken(user, roles);

                return Ok(new { Token = token });
            }

            ModelState.AddModelError("error", "Invalid login attempt.");
            return Unauthorized(ModelState);
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userManager.CreateAsync(patient, patient.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(patient, "Patient");

                var user = await _userManager.FindByEmailAsync(patient.Email);

                var roles = await _userManager.GetRolesAsync(user);

                var token = _jwtTokenService.GenerateJwtToken(patient, roles);
                return Ok(new { Token = token });
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("CheckToken")]
        public IActionResult CheckTokenExpiration()
        {
            var user = HttpContext.User;

            if (user.Identity.IsAuthenticated)
            {
                var expirationClaim = user.FindFirst("exp");

                if (expirationClaim != null && long.TryParse(expirationClaim.Value, out long expirationTime))
                {
                    var currentTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

                    if (expirationTime < currentTime)
                    {
                        return Ok(new { IsTokenExpired = true });
                    }
                    else
                    {
                        return Ok(new { IsTokenExpired = false });
                    }
                }
            }

            return BadRequest(new { Message = "Invalid or expired token" });
        }

        //[HttpPost("Logout")]
        //public async Task<IActionResult> Logout()
        //{
        //    var user = await _userManager.FindByIdAsync(UserId);
        //    var token = _jwtTokenService.GenerateJwtToken(user);
        //    return Ok(new { message = "Logout successful" });
        //}

    }


}
