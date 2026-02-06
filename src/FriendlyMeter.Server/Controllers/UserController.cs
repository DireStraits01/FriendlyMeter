using FriendlyMeter.Server.Interfaces.Services;
using FriendlyMeter.Shared.Dtos;
using FriendlyMeter.Shared.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FriendlyMeter.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> RegisterUser([FromBody] UserDto dto)
    {
        Console.WriteLine("BACK END SERVER");
        try
        {
            await _userService.CreateUser(dto); 
             Console.WriteLine("Done!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error {ex.Message}", ex);
        }

        return Ok(dto); //in the future change to Created();
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginDto dto)
    {
        var token = await _userService.Login(dto.Name, dto.Password);

        if (token == null) return Unauthorized("Invalid credentials");

        return Ok(new {token});
    }

    [HttpGet("users")]
    public async Task<ActionResult<List<UserDto>>> GetUsers()
    {
        var users = await _userService.GetAllUsersAsync();

        return Ok(users);
    }
}
