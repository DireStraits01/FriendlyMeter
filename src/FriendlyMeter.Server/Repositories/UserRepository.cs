using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FriendlyMeter.Server.Data;
using FriendlyMeter.Server.Interfaces.Repositories;
using FriendlyMeter.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace FriendlyMeter.Server.Repositories;
public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<User> CreateUserAsync(User user)
    {
        var newUser = await _context.Users.AddAsync(user);

        return user;
    }
}
