using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FriendlyMeter.Shared.Dtos;
using FriendlyMeter.Shared.Models;

namespace FriendlyMeter.Server.Interfaces.Services;
public interface IUserService
{
     public Task<UserDto> CreateUser(UserDto dto);
}
