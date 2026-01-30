using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FriendlyMeter.Shared.Dtos;
using FriendlyMeter.Shared.Models;

namespace FriendlyMeter.Server.Interfaces.Mappers;

public interface IUserMapper
{
    IEnumerable<UserDto> ToUserDtosList(List<User> users);
}
