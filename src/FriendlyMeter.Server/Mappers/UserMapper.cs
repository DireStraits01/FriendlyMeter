using FriendlyMeter.Server.Interfaces.Mappers;
using FriendlyMeter.Shared.Dtos;
using FriendlyMeter.Shared.Models;

namespace FriendlyMeter.Server.Mappers;

public class UserMapper : IUserMapper
{
    public IEnumerable<UserDto> ToUserDtosList(List<User> users)
    {
        return users.Select(u => new UserDto(
            u.Name, 
            u.Role, 
            u.PhoneNumber, 
            u.Email, 
            u.DateCreated));
    }
}
