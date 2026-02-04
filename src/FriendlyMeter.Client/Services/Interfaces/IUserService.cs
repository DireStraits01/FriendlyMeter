using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FriendlyMeter.Shared.Dtos;

namespace FriendlyMeter.Client.Services.Interfaces;

public interface IUserService
{
    Task<UserDto> UserRegister(UserDto userDto);
}
