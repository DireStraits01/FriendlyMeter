
using FriendlyMeter.Shared.Dtos;
using FriendlyMeter.Shared.Models;

namespace FriendlyMeter.Server.Mappers;
public static class UserMapper
{
    public static UserDto ToDto(this User user)
    {
        return new UserDto(
            user.Name,
            user.Role,
            user.PhoneNumber,
            user.Email,
            user.PasswordHash,
            user.DateCreated
        );
    }
}
