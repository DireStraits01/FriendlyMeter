using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FriendlyMeter.Shared.Dtos;
using FriendlyMeter.Shared.Models;

namespace FriendlyMeter.Server.Factories;
public class UserFactory
{
    public static User CreateUser(UserDto dto)
    {
        return new User(dto.Name, RoleType.User, dto.PhoneNumber, dto.Email, DateTime.UtcNow);
    }
}
