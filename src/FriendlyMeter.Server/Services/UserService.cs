using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FriendlyMeter.Server.Factories;
using FriendlyMeter.Server.Interfaces.Repositories;
using FriendlyMeter.Shared.Dtos;
using FriendlyMeter.Shared.Models;
using Microsoft.AspNetCore.Identity;

namespace FriendlyMeter.Server.Services;

public class UserService
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
}
