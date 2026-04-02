using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoAus.BLL.Dto;
using ProjetoAus.BLL.Services;
using ProjetoAus.Data.interfaces;

namespace ProjetoAus.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(AuthService authService) : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        if (string.IsNullOrWhiteSpace(registerDto.Username) || string.IsNullOrWhiteSpace(registerDto.Password))
        {
            return BadRequest("fields are required");
        }

        var success = await authService.RegisterUserAsync(registerDto);

        if (!success) return BadRequest("User already exists");

        return CreatedAtAction("Register", success);
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var token = await authService.AuthenticateAsync(loginDto);
        
        if (token == null) return Unauthorized("Invalid username or password.");
        
        return Ok(new { Token = token });
    }
}