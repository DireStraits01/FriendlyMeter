using FriendlyMeter.Shared.Dtos;
using FriendlyMeter.Shared.Models;

namespace FriendlyMeter.Server.Factories;
public class UserFactory
{
    public static User CreateUser(UserDto dto)
    {
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
        return new User(dto.Name, RoleType.User, dto.PhoneNumber, dto.Email, passwordHash, DateTime.UtcNow);
    }
}
