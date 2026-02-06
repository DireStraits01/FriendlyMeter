using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using FriendlyMeter.Server.Factories;
using FriendlyMeter.Server.Interfaces.Repositories;
using FriendlyMeter.Server.Interfaces.Services;
using FriendlyMeter.Server.Mappers;
using FriendlyMeter.Shared.Dtos;
using FriendlyMeter.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;

namespace FriendlyMeter.Server.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;


    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<UserDto> CreateUser(UserDto dto)
    {

        var newUser =  UserFactory.CreateUser(dto);

        await _userRepository.CreateUserAsync(newUser);

        await _userRepository.SaveChanges();

        return dto;
    }

     public async Task<string?> Login(string username, string password)
    {
        var user = await _userRepository.GetUserByNameAsync(username);
        if (user == null) return null;

        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password,  user.PasswordHash);
        if (!isPasswordValid) return null;

        string token = CreateJwtToken(user);

        return token;
    }

    private string CreateJwtToken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secret-key-at-least-32-characters-long-for-security"));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(24),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);

    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        var users =  await _userRepository.GetAllUsersAsync();

        return users.Select(UserMapper.ToDto);
    }
}
