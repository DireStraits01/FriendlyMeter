using FriendlyMeter.Shared.Dtos;
using System.Net.Http.Json;
using FriendlyMeter.Client.Services.Interfaces;

namespace FriendlyMeter.Client.Services;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<UserDto> UserRegister(UserDto userDto)
    {
        try
        {
             var response = await _httpClient.PostAsJsonAsync("api/User/register", userDto);
             var user = await response.Content.ReadFromJsonAsync<UserDto>();
               return user;
        }
       catch (Exception ex)
        {
            System.Console.WriteLine($"MESSAGE {ex.Message}", ex);
            return null;
        }
        
    }
}