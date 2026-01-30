using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FriendlyMeter.Shared.Models;

namespace FriendlyMeter.Server.Interfaces.Repositories;
public interface IUserRepository
{
    Task SaveChanges();
    Task<User> CreateUserAsync(User user);
    Task<List<User>> GetAllUsersAsync();
}
