﻿using Microsoft.AspNetCore.Mvc;
using united_movers_api.Models;
using united_movers_api.Services;

namespace united_movers_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST: api/Auth/Login
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Error checks
            if (String.IsNullOrEmpty(request.UserName))
            {
                return BadRequest(new LoginResponse { IsAuthenticated = false, Message = "User name needs to be entered" });
            }
            else if (String.IsNullOrEmpty(request.Password))
            {
                return BadRequest(new LoginResponse { IsAuthenticated = false, Message = "Password needs to be entered" });
            }

            // Try login
            var response = _authService.Login(request);

            // Return responses
            if (response != null)
            {
                return Ok(response);
            }

            return BadRequest(new LoginResponse { IsAuthenticated = false, Message = "User login unsuccessful" });

        }

        // POST: api/Auth/ChangePassword
        [HttpPost("ChangePassword")]
        public IActionResult ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var response = _authService.ChangePassword(request);
            if (response)
            {
                return Ok(new { HasPasswordChanged = true, Message = "Password changed successfully." });
            }
            else
            {
                return BadRequest(new { HasPasswordChanged = false, Message = "Password change unsuccessful." });
            }
        }

        // POST: api/Auth/ForgotPassword
        [HttpPost("ForgotPassword")]
        public IActionResult ForgotPassword([FromBody] ChangePasswordRequest request)
        {
            var response = _authService.ForgotPassword(request);
            if (response)
            {
                return Ok(new { HasPasswordChanged = true, Message = "Password reset was done successfully." });
            }
            else
            {
                return BadRequest(new { HasPasswordChanged = false, Message = "Password reset was unsuccessful." });
            }
        }

    }
}
