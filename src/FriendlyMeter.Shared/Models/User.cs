using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendlyMeter.Shared.Models;

 public class User : BaseEntity
{
    public string Name { get; set; }
    public RoleType Role { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string Password {get; set;}
    public List<Flat>? OwnFlats { get; set; }
    public List<Flat>? RentFlats { get; set; }

    public User (string name, RoleType role, string phoneNumber, string? email, string password, DateTime dateCreated)
    {
        Name = name;
        Role = role;
        PhoneNumber = phoneNumber;
        Email = email;
        Password = password;
        DateCreated = dateCreated;
    }
}
