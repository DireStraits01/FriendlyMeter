using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FriendlyMeter.Server.Factories;
using FriendlyMeter.Server.Interfaces.Mappers;
using FriendlyMeter.Server.Interfaces.Repositories;
using FriendlyMeter.Server.Interfaces.Services;
using FriendlyMeter.Shared.Dtos;
using FriendlyMeter.Shared.Models;
using Microsoft.AspNetCore.Identity;

namespace FriendlyMeter.Server.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserMapper _userMapper;

    public UserService(IUserRepository userRepository, IUserMapper userMapper)
    {
        _userRepository = userRepository;
        _userMapper = userMapper;
    }
    public async Task<UserDto> CreateUser(UserDto dto)
    {

        var newUser =  UserFactory.CreateUser(dto);

        await _userRepository.CreateUserAsync(newUser);

        await _userRepository.SaveChanges();

        return dto;
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        var users =  await _userRepository.GetAllUsersAsync();

        var usersDto = _userMapper.ToUserDtosList(users);

        return usersDto;
    }
}
